using System.Data.SqlClient;
using Dapper;
using Supermarket.Domain.Entities;
using Supermarket.Domain.Repositories.Interfaces;

namespace Supermarket.Data.Dapper.Repositories
{
    public class ProductRepositoryDapper : IProductRepository
    {
        private readonly string _connectionString;

        public ProductRepositoryDapper(string connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var query = "SELECT * FROM Products";
            using (var connection = new SqlConnection(_connectionString))
            {
                var products = await connection.QueryAsync<Product>(query);
                return products;
            }
        }

        public async Task<IEnumerable<Product>> GetAllByFilterAsync(string? name, int? stock, decimal? price)
        {
            var queryBuilder = new System.Text.StringBuilder("SELECT * FROM Products WHERE 1=1");
            var parameters = new DynamicParameters();

            if (!string.IsNullOrEmpty(name))
            {
                queryBuilder.Append(" AND Name LIKE @Name");
                parameters.Add("Name", $"%{name}%");
            }
            if (stock.HasValue)
            {
                queryBuilder.Append(" AND Stock = @Stock");
                parameters.Add("Stock", stock.Value);
            }
            if (price.HasValue)
            {
                queryBuilder.Append(" AND Price = @Price");
                parameters.Add("Price", price.Value);
            }

            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryAsync<Product>(queryBuilder.ToString(), parameters);
            }
        }

        public async Task AddAsync(Product? product)
        {
            var command = @"INSERT INTO Products (Name, Description, Price, Stock, SupplierId)
                          VALUES (@Name, @Description, @Price, @Stock, @SupplierId)";
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.ExecuteAsync(command, new
                {
                    product.Name,
                    product.Description,
                    product.Price,
                    product.Stock,
                    product.SupplierId
                });
            }
        }

        public async Task DeleteAsync(int id)
        {
            var command = "DELETE FROM Products WHERE Id = @Id";
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.ExecuteAsync(command, new { Id = id });
            }
        }

        public async Task UpdateAsync(Product? product)
        {
            var command = @"UPDATE Products 
                            SET Name = @Name, 
                                Description = @Description, 
                                Price = @Price, 
                                Stock = @Stock, 
                                SupplierId = @SupplierId
                            WHERE ProductId = @ProductId";
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.ExecuteAsync(command, new
                {
                    product.Name,
                    product.Description,
                    product.Price,
                    product.Stock,
                    product.SupplierId,
                    product.Id
                });
            }
        }
    }
}
