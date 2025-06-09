using Supermarket.Api.Enums;
using Supermarket.Domain.Repositories.Interfaces;

namespace Supermarket.Api.Factories;

public interface ISaleRepositoryFactory
{
    public ISaleRepository Create(OrmType ormType);
}