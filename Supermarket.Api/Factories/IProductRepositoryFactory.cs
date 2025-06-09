using Supermarket.Api.Enums;
using Supermarket.Domain.Repositories.Interfaces;

namespace Supermarket.Api.Factories
{
    public interface IProductRepositoryFactory
    {
        IProductRepository Create(OrmType ormType);
    }
}
