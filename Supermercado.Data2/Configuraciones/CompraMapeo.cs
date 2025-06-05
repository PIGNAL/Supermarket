using FluentNHibernate.Mapping;
using Supermercado.Domain.Entidades;

namespace Supermercado.Data2.Configuraciones;

public class CompraMapeo : ClassMap<Compra>
{
    public CompraMapeo()
    {
        Table("Compras");
        Id(c => c.CompraID).GeneratedBy.Identity();
        Map(c => c.Fecha);
        Map(c => c.ProveedorID);
        Map(c => c.Total);
        HasMany(c => c.Detalles).Inverse().Cascade.All();
    }
}