using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Supermercado.Domain.Entidades;

namespace Supermercado.Data.Configuraciones
{
    internal class CompraConfiguracion : IEntityTypeConfiguration<Compra>
    {
        public void Configure(EntityTypeBuilder<Compra> builder)
        {
            builder.ToTable("Compras");
            builder.HasKey(c => c.CompraID);
            builder.HasMany(c => c.Detalles)
                   .WithOne(d => d.Compra)
                   .IsRequired();
        }
    }
}
