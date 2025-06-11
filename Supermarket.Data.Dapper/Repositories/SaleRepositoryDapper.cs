using System.Data.SqlClient;
using Dapper;
using Supermarket.Domain.Entities;
using Supermarket.Domain.Repositories.Interfaces;

namespace Supermarket.Data.Dapper.Repositories
{
    public class SaleRepositoryDapper : ISaleRepository
    {
        private readonly string _connectionString;
        public SaleRepositoryDapper(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task AddAsync(Sale? sale)
        {
            var ventaCommand = @"INSERT INTO Sales (Date, ClientId, Total)
                                 VALUES (@Date, @ClientId, @Total);
                                 SELECT CAST(SCOPE_IDENTITY() as int);";

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var saleId = await connection.ExecuteScalarAsync<int>(ventaCommand, new
                        {
                            sale.Date,
                            sale.ClientId,
                            sale.Total
                        }, transaction);

                        var saleDetailCommand = @"INSERT INTO SaleDetail (SaleId, ProductId, Quantity, UnitPrice)
                                               VALUES (@SaleId, @ProductId, @Quantity, @UnitPrice);";

                        foreach (var saleDetail in sale.SaleDetails)
                        {
                            await connection.ExecuteAsync(saleDetailCommand, new
                            {
                                Id = saleId,
                                saleDetail.ProductId,
                                saleDetail.Quantity,
                                saleDetail.UnitPrice
                            }, transaction);
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public async Task<IEnumerable<Sale>> GetSalesByProductAndClientAsync(int clientId, int productId)
        {
            var salesDict = new Dictionary<int, Sale>();

            var query = @"
                SELECT s.Id, s.Date, s.ClientId, s.Total,
                       sd.SaleId as SaleDetailId, sd.ProductId, sd.Quantity, sd.UnitPrice
                FROM Sales s
                INNER JOIN SaleDetail sd ON s.Id = sd.SaleId
                WHERE s.ClientId = @ClientId AND sd.ProductId = @ProductId
                ORDER BY v.Id, sd.ProductId";

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var result = await connection.QueryAsync<Sale, SaleDetail, Sale>(
                    query,
                    (sale, saleDetail) =>
                    {
                        if (!salesDict.TryGetValue(sale.Id, out var saleEntry))
                        {
                            sale.SaleDetails = new List<SaleDetail>();
                            salesDict.Add(sale.Id, sale);
                            saleEntry = sale;
                        }
                        if (saleDetail != null)
                        {
                            saleEntry.SaleDetails.Add(saleDetail);
                        }
                        return saleEntry;
                    },
                    new { ClientId = clientId, ProductId = productId },
                    splitOn: "SaleDetailId"
                );

                return salesDict.Values;
            }
        }
    }
}
