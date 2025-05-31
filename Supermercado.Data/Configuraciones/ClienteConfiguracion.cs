using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Supermercado.Domain.Entidades;

namespace Supermercado.Data.Configuraciones
{
    public class ClienteConfiguracion: IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");
            builder.HasKey(c => c.ClienteID);
            builder.HasMany(c => c.Ventas).WithOne(c => c.Cliente);
        }
    }
}
