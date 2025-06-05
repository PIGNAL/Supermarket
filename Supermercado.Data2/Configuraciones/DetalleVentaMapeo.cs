using FluentNHibernate.Mapping;
using Supermercado.Domain.Entidades;

namespace Supermercado.Data2.Configuraciones;

public class DetalleVentaMapeo : ClassMap<DetalleVenta>
{
    public DetalleVentaMapeo()
    {
        Table("DetalleVenta");
        CompositeId()
            .KeyProperty(dv => dv.VentaID, "VentaID")
            .KeyProperty(dv => dv.ProductoID, "ProductoID");
        Map(d => d.Cantidad);
        Map(d => d.PrecioUnitario);
        References(dv => dv.Venta)
            .Column("VentaID")
            .Not.Insert()
            .Not.Update();
    }
}