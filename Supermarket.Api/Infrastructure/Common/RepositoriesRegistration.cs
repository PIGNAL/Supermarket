using Supermarket.Api.Factories;
using Supermarket.Data.Dapper.Repositories;
using Supermarket.Data.EFCore.Repositories;
using Supermarket.Data.NHibernate.Repositories;

namespace Supermarket.Api.Infrastructure.Common
{
    public static class RepositoriesRegistration
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddScoped<ProductRepository>();
            services.AddScoped<ProductRepositoryNhibernate>();
            services.AddScoped<ProductRepositoryDapper>(provider => new ProductRepositoryDapper(connectionString));
            services.AddScoped<IProductRepositoryFactory, ProductRepositoryFactory>();
            services.AddScoped<SaleRepository>();
            services.AddScoped<SaleRepositoryNhibernate>();
            services.AddScoped<SaleRepositoryDapper>(provider => new SaleRepositoryDapper(connectionString));
            services.AddScoped<ISaleRepositoryFactory, SaleRepositoryFactory>();

            return services;
        }
    }
}
