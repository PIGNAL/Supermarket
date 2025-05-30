using Microsoft.EntityFrameworkCore;
using Supermercado.Dominio.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Supermercado.Data.Configuraciones
{
    public class DetalleVentaConfiguracion : IEntityTypeConfiguration<DetalleVenta>
    {
        public void Configure(EntityTypeBuilder<DetalleVenta> builder)
        {
            builder.ToTable("DetalleVenta");
            builder.HasKey(dc => new { dc.VentaID, dc.ProductoID });
            builder.HasOne(dv => dv.Venta).WithMany(p => p.Detalles)
                   .IsRequired();
            builder.HasOne(dv => dv.Producto)
                .WithMany()
                .HasForeignKey(dv => dv.ProductoID)
                .IsRequired();

        }
    }
}
