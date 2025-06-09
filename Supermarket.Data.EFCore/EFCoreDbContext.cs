using Microsoft.EntityFrameworkCore;
using Supermarket.Domain.Entities;

namespace Supermarket.Data.EFCore
{
    public class SupermarketDbContext : DbContext
    {
        public SupermarketDbContext(DbContextOptions<SupermarketDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SupermarketDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseDetail> PurchaseDetails { get; set; }
        public DbSet<SaleDetail> SaleDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Sale> Sales { get; set; }
    }
}
