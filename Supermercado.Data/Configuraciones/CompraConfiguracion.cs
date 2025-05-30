using Microsoft.EntityFrameworkCore;
using Supermercado.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
