using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Supermarket.Data.NHibernate.Mappers;
using Supermarket.Data.NHibernate.Repositories;
using Supermarket.Domain.Repositories.Interfaces;

namespace Supermarket.Api.Infrastructure
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
                    m.FluentMappings.AddFromAssemblyOf<ProductMap>()) 
                .ExposeConfiguration(cfg =>
                {
                    cfg.SetProperty(NHibernate.Cfg.Environment.ShowSql, "true");
                    cfg.SetProperty(NHibernate.Cfg.Environment.FormatSql, "true");
                    cfg.SetProperty(NHibernate.Cfg.Environment.Hbm2ddlKeyWords, "auto-quote");
                })
                .BuildSessionFactory();

            services.AddSingleton(sessionFactory);
            services.AddScoped(factory => sessionFactory.OpenSession());
            services.AddScoped<ISaleRepository, SaleRepository2>();
            return services;
        }
    }
}
