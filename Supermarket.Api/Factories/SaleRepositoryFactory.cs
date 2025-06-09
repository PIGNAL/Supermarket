using Supermarket.Api.Enums;
using Supermarket.Data.Dapper.Repositories;
using Supermarket.Data.EFCore.Repositories;
using Supermarket.Data.NHibernate.Repositories;
using Supermarket.Domain.Repositories.Interfaces;

namespace Supermarket.Api.Factories
{
    public class SaleRepositoryFactory : ISaleRepositoryFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public SaleRepositoryFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public ISaleRepository Create(OrmType ormType)
        {
            return ormType switch
            {
                OrmType.EfCore => (ISaleRepository)_serviceProvider.GetService(typeof(SaleRepository)),
                OrmType.Dapper => (ISaleRepository)_serviceProvider.GetService(typeof(SaleRepository2)),
                OrmType.NHibernate => (ISaleRepository)_serviceProvider.GetService(typeof(SaleRepository3)),
                _ => throw new NotImplementedException()
            };
        }
    }
}
