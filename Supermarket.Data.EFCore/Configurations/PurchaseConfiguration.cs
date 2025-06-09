using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Supermarket.Domain.Entities;

namespace Supermarket.Data.EFCore.Configurations
{
    internal class PurchaseConfiguration : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.ToTable("Purchases");
            builder.HasKey(p => p.Id);
            builder.HasMany(p => p.PurchaseDetails)
                   .WithOne(pd => pd.Purchase)
                   .IsRequired();
        }
    }
}
