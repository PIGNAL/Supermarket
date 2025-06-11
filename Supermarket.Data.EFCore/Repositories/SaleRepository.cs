using Microsoft.EntityFrameworkCore;
using Supermarket.Domain.Entities;
using Supermarket.Domain.Repositories.Interfaces;

namespace Supermarket.Data.EFCore.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly SupermarketDbContext _context;
        public SaleRepository(SupermarketDbContext context)
        {
            _context = context;
        }
        public Task AddAsync(Sale? sale)
        {
            if (sale == null)
            {
                throw new ArgumentNullException(nameof(sale), "La sale no puede ser nulo.");
            }
            _context.Sales.Add(sale);
            return _context.SaveChangesAsync();
        }

        public Task<IEnumerable<Sale>> GetSalesByProductAndClientAsync(int clientId, int productId)
        {
            return _context.Sales.Where(v => v.ClientId == clientId && v.SaleDetails.FirstOrDefault(dv => dv.ProductId == productId) != null)
                .Include(v => v.SaleDetails)
                .ToListAsync()
                .ContinueWith(IEnumerable<Sale> (task) => task.Result);
        }
    }
}
