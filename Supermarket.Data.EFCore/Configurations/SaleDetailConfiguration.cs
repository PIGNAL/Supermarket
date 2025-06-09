using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Supermarket.Domain.Entities;

namespace Supermarket.Data.EFCore.Configurations
{
    public class SaleDetailConfiguration : IEntityTypeConfiguration<SaleDetail>
    {
        public void Configure(EntityTypeBuilder<SaleDetail> builder)
        {
            builder.ToTable("SaleDetail");
            builder.HasKey(sd => new { sd.SaleId, sd.ProductId });
            builder.HasOne(sd => sd.Product)
                .WithMany()
                .HasForeignKey(sd => sd.ProductId)
                .IsRequired();

        }
    }
}
