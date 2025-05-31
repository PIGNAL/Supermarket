using Microsoft.EntityFrameworkCore;
using Supermercado.Domain.Entidades;
using Supermercado.Domain.Repositorios.Interfaces;

namespace Supermercado.Data.Repositorios
{
    public class ProductoRepositorio : IProductoRepositorio
    {
        private readonly SupermercadoDbContext _context;
        public ProductoRepositorio(SupermercadoDbContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<Producto>> TraerTodosAsync()
        {
            return _context.Productos
                .ToListAsync()
                .ContinueWith(IEnumerable<Producto> (task) => task.Result);
        }

        public Task<IEnumerable<Producto>> TraerTodosPorFiltro(string? nombre, int? stock, decimal? precio)
        {
            var query = _context.Productos.AsQueryable();

            if (!string.IsNullOrEmpty(nombre))
            {
                query = query.Where(p => p.Nombre.Contains(nombre));
            }

            if (stock.HasValue)
            {
                query = query.Where(p => p.Stock == stock);
            }

            if (precio.HasValue && precio > 0)
            {
                query = query.Where(p => p.Precio == precio);
            }

            return query.ToListAsync().ContinueWith<IEnumerable<Producto>>(task => task.Result);
        }

        public Task Alta(Producto producto)
        {
            if (producto == null)
            {
                throw new ArgumentNullException(nameof(producto), "El producto no puede ser nulo.");
            }
            _context.Productos.Add(producto);
            return _context.SaveChangesAsync();
        }

        public Task Baja(int productoId)
        {
            var producto = _context.Productos.Find(productoId);
            if (producto == null)
            {
                throw new KeyNotFoundException($"Producto con ID {productoId} no encontrado.");
            }
            _context.Productos.Remove(producto);
            return _context.SaveChangesAsync();
        }

        public Task Modificacion(Producto producto)
        {
            if (producto == null)
            {
                throw new ArgumentNullException(nameof(producto), "El producto no puede ser nulo.");
            }
            var existingProducto = _context.Productos.Find(producto.ProductoID);
            if (existingProducto == null)
            {
                throw new KeyNotFoundException($"Producto con ID {producto.ProductoID} no encontrado.");
            }
            existingProducto.Nombre = producto.Nombre;
            existingProducto.Stock = producto.Stock;
            existingProducto.Precio = producto.Precio;
            existingProducto.Descripcion = producto.Descripcion;
            return _context.SaveChangesAsync();
        }
    }
}
