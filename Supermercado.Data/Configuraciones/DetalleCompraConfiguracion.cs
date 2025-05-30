using Microsoft.EntityFrameworkCore;
using Supermercado.Dominio.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Supermercado.Data.Configuraciones
{
    public class DetalleCompraConfiguracion : IEntityTypeConfiguration<DetalleCompra>
    {
        public void Configure(EntityTypeBuilder<DetalleCompra> builder)
        {
            builder.ToTable("DetalleCompra");
            builder.HasKey(dc => new { dc.CompraID, dc.ProductoID });
            builder.HasOne(dc => dc.Compra)
                   .WithMany(v => v.Detalles)
                   .HasForeignKey(dc => dc.CompraID)
                   .IsRequired();
            builder.HasOne(dc => dc.Producto)
                   .WithMany()
                   .HasForeignKey(dc => dc.ProductoID)
                   .IsRequired();
        }
    }
}
