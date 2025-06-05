using FluentNHibernate.Mapping;
using Supermercado.Domain.Entidades;

namespace Supermercado.Data2.Configuraciones
{
    public class ProductoMapeo : ClassMap<Producto>
    {
        public ProductoMapeo()
        {
            Table("Productos");
            Id(p => p.ProductoID).GeneratedBy.Identity();
            Map(p => p.Nombre);
            Map(p => p.Descripcion);
            Map(p => p.Precio);
            Map(p => p.Stock);
            Map(p => p.ProveedorID);
        }
    }
}
