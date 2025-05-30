using Microsoft.EntityFrameworkCore;
using Supermercado.Dominio.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Supermercado.Data.Configuraciones
{
    public class ProductoConfiguracion : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.ToTable("Productos");
            builder.HasKey(p => p.ProductoID);
        }
    }
}
