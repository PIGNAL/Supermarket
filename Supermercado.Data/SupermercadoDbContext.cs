using Microsoft.EntityFrameworkCore;
using Supermercado.Domain.Entidades;

namespace Supermercado.Data
{
    public class SupermercadoDbContext : DbContext
    {
        public SupermercadoDbContext(DbContextOptions<SupermercadoDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SupermercadoDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<DetalleCompra> DetalleCompra { get; set; }
        public DbSet<DetalleVenta> DetalleVenta { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Venta> Ventas { get; set; }
    }
}
