using Supermarket.Domain.Entities;

namespace Supermarket.Domain.Repositories.Interfaces;

public interface ISaleRepository
{
    Task Add(Sale? sale);

    Task<IEnumerable<Sale>> GetSalesByProductAndClient(int clientId, int productId);
}
    