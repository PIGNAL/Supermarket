using System.Reflection;

namespace Supermarket.Api.Infrastructure.Common
{
    public static class MediatRRegistration
    {
        public static IServiceCollection AddMediatRRegistration(this IServiceCollection services)
        {
            var currentAssembly = Assembly.GetExecutingAssembly();
            services.AddMediatR(m =>
            {
                m.RegisterServicesFromAssemblies(currentAssembly);
            });

            return services;
        }
    }
}
