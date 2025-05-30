using Microsoft.EntityFrameworkCore;
using Supermercado.Dominio.Entidades;

namespace Supermercado.Data
{
    public class SupermercadoDbContext : DbContext
    {
        public SupermercadoDbContext(DbContextOptions<SupermercadoDbContext> options)
            : base(options)
        {
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(
        //        @"Server=localhost\MSSQLSERVER01;User Id=JONI\joni_;Password=;Initial Catalog=Supermercado;TrustServerCertificate=True;Integrated Security=True;");
        //}

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
