using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Supermarket.Domain.Entities;

namespace Supermarket.Data.EFCore.Configurations
{
    public class PurchaseDetailConfiguration : IEntityTypeConfiguration<PurchaseDetail>
    {
        public void Configure(EntityTypeBuilder<PurchaseDetail> builder)
        {
            builder.ToTable("PurchaseDetail");
            builder.HasKey(pd => new {  pd.PurchaseId, pd.ProductId });
            builder.HasOne(pd => pd.Purchase)
                   .WithMany(p => p.PurchaseDetails)
                   .HasForeignKey(pd => pd.PurchaseId)
                   .IsRequired();
            builder.HasOne(pd => pd.Product)
                   .WithMany()
                   .HasForeignKey(pd => pd.ProductId)
                   .IsRequired();
        }
    }
}
