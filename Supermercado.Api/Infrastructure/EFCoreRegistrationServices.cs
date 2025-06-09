using Microsoft.EntityFrameworkCore;
using Supermarket.Data.EFCore;
using Supermarket.Data.EFCore.Repositories;
using Supermarket.Domain.Repositories.Interfaces;

namespace Supermarket.Api.Infrastructure
{
    public static class EFCoreRegistrationServices
    {
        public static IServiceCollection AddEFCoreInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SupermarketDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            return services;
        }
    }
}
