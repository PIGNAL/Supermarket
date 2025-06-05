using FluentNHibernate.Mapping;
using Supermercado.Domain.Entidades;

namespace Supermercado.Data2.Configuraciones;

public class DetalleCompraMapeo : ClassMap<DetalleCompra>
{
    public DetalleCompraMapeo()
    {
        Table("DetalleCompra");
        CompositeId()
            .KeyProperty(dv => dv.CompraID, "CompraID")
            .KeyProperty(dv => dv.ProductoID, "ProductoID");
        Map(d => d.Cantidad);
        Map(d => d.PrecioUnitario);
        References(d => d.Compra).Not.Nullable();
        References(d => d.Producto).Not.Nullable();
    }
}