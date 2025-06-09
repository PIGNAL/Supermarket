using Supermarket.Api.Enums;
using Supermarket.Data.Dapper.Repositories;
using Supermarket.Data.EFCore.Repositories;
using Supermarket.Data.NHibernate.Repositories;
using Supermarket.Domain.Repositories.Interfaces;

namespace Supermarket.Api.Factories
{
    public class ProductRepositoryFactory : IProductRepositoryFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public ProductRepositoryFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IProductRepository Create(OrmType ormType)
        {
            return ormType switch
            {
                OrmType.EfCore => (IProductRepository)_serviceProvider.GetService(typeof(ProductRepository)),
                OrmType.Dapper => (IProductRepository)_serviceProvider.GetService(typeof(ProductRepository2)),
                OrmType.NHibernate => (IProductRepository)_serviceProvider.GetService(typeof(ProductRepository3)),
                _ => throw new NotImplementedException()
            };
        }
    }
}
