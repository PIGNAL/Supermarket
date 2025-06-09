using FluentNHibernate.Mapping;
using Supermarket.Domain.Entities;

namespace Supermarket.Data.NHibernate.Mappers;

public class ClientMap : ClassMap<Client>
{
    public ClientMap()
    {
        Table("Clients");
        Id(c => c.Id).GeneratedBy.Identity();
        Map(c => c.Name).Not.Nullable().Length(255).CustomSqlType("nvarchar(255)");
        Map(c => c.Address).Nullable().Length(255).CustomSqlType("nvarchar(255)");
        Map(c => c.Phone).Nullable().Length(255).CustomSqlType("nvarchar(255)");
    }
}