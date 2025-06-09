using NHibernate;
using NHibernate.Linq;
using Supermarket.Domain.Entities;
using Supermarket.Domain.Repositories.Interfaces;

namespace Supermarket.Data.NHibernate.Repositories
{
    public class ProductRepository2 : IProductRepository
    {
        private readonly ISession _session;
        public ProductRepository2(ISession session)
        {
            _session = session;
        }

        public Task<IEnumerable<Product>> GetAllAsync()
        {
            return _session.Query<Product>()
                .ToListAsync()
                .ContinueWith(IEnumerable<Product> (task) => task.Result);
        }

        public Task<IEnumerable<Product>> GetAllByFilterAsync(string? name, int? stock, decimal? price)
        {
            var query = _session.Query<Product>().AsQueryable();

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
                throw new ArgumentNullException(nameof(product), "The product can't be null");
            }
            return _session.SaveOrUpdateAsync(product);
        }

        public async Task DeleteAsync(int id)
        {
            var producto = await _session.GetAsync<Product>(id);
            if (producto == null)
            {
                throw new KeyNotFoundException($"Product with id {id} was not found.");
            }
            await _session.DeleteAsync(producto);
            await _session.FlushAsync();
        }

        public async Task UpdateAsync(Product? product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product), "The product can't be null");
            }
            var existingProduct = await _session.GetAsync<Product>(product.Id);
            if (existingProduct == null)
            {
                throw new KeyNotFoundException($"Product with id {product.Id} was not found.");
            }
            existingProduct.Name = product.Name;
            existingProduct.Stock = product.Stock;
            existingProduct.Price = product.Price;
            existingProduct.Description = product.Description;
            await _session.SaveOrUpdateAsync(existingProduct);
            await _session.FlushAsync();
        }
    }
}
