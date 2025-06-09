using Microsoft.EntityFrameworkCore;
using Supermarket.Domain.Entities;
using Supermarket.Domain.Repositories.Interfaces;

namespace Supermarket.Data.EFCore.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly SupermarketDbContext _context;
        public ProductRepository(SupermarketDbContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<Product>> GetAllAsync()
        {
            return _context.Products
                .ToListAsync()
                .ContinueWith(IEnumerable<Product> (task) => task.Result);
        }

        public Task<IEnumerable<Product>> GetAllByFilterAsync(string? name, int? stock, decimal? price)
        {
            var query = _context.Products.AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(p => p.Name.Contains(name));
            }

            if (stock.HasValue)
            {
                query = query.Where(p => p.Stock == stock);
            }

            if (price.HasValue && price > 0)
            {
                query = query.Where(p => p.Price == price);
            }

            return query.ToListAsync().ContinueWith<IEnumerable<Product>>(task => task.Result);
        }

        public Task AddAsync(Product? product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product), "El product no puede ser nulo.");
            }
            _context.Products.Add(product);
            return _context.SaveChangesAsync();
        }

        public Task DeleteAsync(int id)
        {
            var producto = _context.Products.Find(id);
            if (producto == null)
            {
                throw new KeyNotFoundException($"The product with Id {id} was not found.");
            }
            _context.Products.Remove(producto);
            return _context.SaveChangesAsync();
        }

        public Task UpdateAsync(Product? product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product), "The product can't be null");
            }
            var exitingProduct = _context.Products.Find(product.Id);
            if (exitingProduct == null)
            {
                throw new KeyNotFoundException($"The product with Id {product.Id} was not found.");
            }
            exitingProduct.Name = product.Name;
            exitingProduct.Stock = product.Stock;
            exitingProduct.Price = product.Price;
            exitingProduct.Description = product.Description;
            return _context.SaveChangesAsync();
        }
    }
}
