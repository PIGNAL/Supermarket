

using Supermarket.Domain.Entities;

namespace Supermarket.Domain.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();

        Task<IEnumerable<Product>> GetAllByFilterAsync(string? name, int? stock, decimal? price);

        Task AddAsync(Product? product);
        Task DeleteAsync(int id);
        Task UpdateAsync(Product? product);
    }
}
