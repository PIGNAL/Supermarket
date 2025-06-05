using FluentNHibernate.Mapping;
using Supermercado.Domain.Entidades;

namespace Supermercado.Data2.Configuraciones;

public class ClienteMapeo : ClassMap<Cliente>
{
    public ClienteMapeo()
    {
        Table("Clientes");
        Id(c => c.ClienteID).GeneratedBy.Identity();
        Map(c => c.Nombre).Not.Nullable().Length(255).CustomSqlType("nvarchar(255)");
        Map(c => c.Direccion).Nullable().Length(255).CustomSqlType("nvarchar(255)");
        Map(c => c.Telefono).Nullable().Length(255).CustomSqlType("nvarchar(255)");
    }
}