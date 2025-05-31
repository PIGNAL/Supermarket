using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Supermercado.Domain.Entidades;

namespace Supermercado.Data.Configuraciones
{
    public class DetalleVentaConfiguracion : IEntityTypeConfiguration<DetalleVenta>
    {
        public void Configure(EntityTypeBuilder<DetalleVenta> builder)
        {
            builder.ToTable("DetalleVenta");
            builder.HasKey(dc => new { dc.VentaID, dc.ProductoID });
            builder.HasOne(dv => dv.Producto)
                .WithMany()
                .HasForeignKey(dv => dv.ProductoID)
                .IsRequired();

        }
    }
}
