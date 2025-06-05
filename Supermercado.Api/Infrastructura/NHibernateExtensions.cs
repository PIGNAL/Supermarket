using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Supermercado.Data.Repositorios;
using Supermercado.Data2.Configuraciones;
using Supermercado.Data2.Repositorios;
using Supermercado.Domain.Repositorios.Interfaces;

namespace Supermercado.Api.Infrastructura
{
    public static class NHibernateExtensions
    {
        public static IServiceCollection AddNHibernate(this IServiceCollection services, IConfiguration configuration)
        {
            var sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                    .ConnectionString(configuration.GetConnectionString("DefaultConnection"))
                    .ShowSql())
                .Mappings(m =>
                    m.FluentMappings.AddFromAssemblyOf<ProductoMapeo>()) // Asegurate que todos tus mapeos estén en el mismo ensamblado
                .ExposeConfiguration(cfg =>
                {
                    cfg.SetProperty(NHibernate.Cfg.Environment.ShowSql, "true");
                    cfg.SetProperty(NHibernate.Cfg.Environment.FormatSql, "true");
                    cfg.SetProperty(NHibernate.Cfg.Environment.Hbm2ddlKeyWords, "auto-quote");
                })
                .BuildSessionFactory();

            services.AddSingleton(sessionFactory);
            services.AddScoped(factory => sessionFactory.OpenSession());

            // Repositorios
            services.AddScoped<IProductoRepositorio, ProductoRepositorio2>();
            services.AddScoped<IVentaRepositorio, VentaRepositorio2>();
            return services;
        }
    }
}
