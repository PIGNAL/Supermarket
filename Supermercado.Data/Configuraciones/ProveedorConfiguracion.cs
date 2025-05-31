using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Supermercado.Domain.Entidades;

namespace Supermercado.Data.Configuraciones
{
    public class ProveedorConfiguracion : IEntityTypeConfiguration<Proveedor>
    {
        public void Configure(EntityTypeBuilder<Proveedor> builder)
        {
            builder.ToTable("Proveedores");
            builder.HasKey(p => p.ProveedorID);
            builder.HasMany(p => p.Productos)
                   .WithOne(pr => pr.Proveedor)
                   .IsRequired();
            builder.HasMany(p => p.Compras).WithOne(c => c.Proveedor).IsRequired();
        }
    }
}
