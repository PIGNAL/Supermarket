using FluentNHibernate.Mapping;
using Supermercado.Domain.Entidades;

namespace Supermercado.Data2.Configuraciones;

public class ProveedorMapeo : ClassMap<Proveedor>
{
    public ProveedorMapeo()
    {
        Table("Proveedores");
        Id(p => p.ProveedorID).GeneratedBy.Identity();
        Map(p => p.Nombre).Not.Nullable();
        Map(p => p.Contacto).Nullable();
        Map(p => p.Direccion).Nullable();
        HasMany(p => p.Productos).Inverse().Cascade.All();
        HasMany(p => p.Compras).Inverse().Cascade.All();
    }
}