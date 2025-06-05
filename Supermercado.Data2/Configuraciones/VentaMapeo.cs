using FluentNHibernate.Mapping;
using Supermercado.Domain.Entidades;

namespace Supermercado.Data2.Configuraciones;

public class VentaMapeo : ClassMap<Venta>
{
    public VentaMapeo()
    {
        Table("Ventas");
        Id(v => v.VentaID).GeneratedBy.Identity();
        Map(v => v.Fecha).Not.Nullable();
        Map(v => v.ClienteID).Nullable();
        Map(v => v.Total).Nullable();
        HasMany(c => c.Detalles).Inverse().Cascade.All();
        References(d => d.Cliente).Column("ClienteID")
            .Not.Insert()
            .Not.Update();

    }
}