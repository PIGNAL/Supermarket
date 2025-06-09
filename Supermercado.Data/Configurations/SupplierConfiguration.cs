using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Supermarket.Domain.Entities;

namespace Supermarket.Data.EFCore.Configurations
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("Suppliers");
            builder.HasKey(s => s.Id);
            builder.HasMany(s => s.Products)
                   .WithOne(p => p.Supplier)
                   .IsRequired();
            builder.HasMany(s => s.Purchases).WithOne(p => p.Supplier).IsRequired();
        }
    }
}
