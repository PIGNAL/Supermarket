using Supermarket.Domain.Entities;

namespace Supermarket.Domain.Repositories.Interfaces;

public interface ISaleRepository
{
    Task AddAsync(Sale? sale);

    Task<IEnumerable<Sale>> GetSalesByProductAndClientAsync(int clientId, int productId);
}
    