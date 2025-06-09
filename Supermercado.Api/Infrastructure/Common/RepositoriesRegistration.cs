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
            services.AddScoped<ProductRepository2>();
            services.AddScoped<ProductRepository3>(provider => new ProductRepository3(connectionString));
            services.AddScoped<IProductRepositoryFactory, ProductRepositoryFactory>();
            return services;
        }
    }
}
