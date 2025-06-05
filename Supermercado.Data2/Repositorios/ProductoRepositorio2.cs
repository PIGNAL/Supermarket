using NHibernate;
using NHibernate.Linq;
using Supermercado.Domain.Entidades;
using Supermercado.Domain.Repositorios.Interfaces;

namespace Supermercado.Data2.Repositorios
{
    public class ProductoRepositorio2 : IProductoRepositorio
    {
        private readonly ISession _session;
        public ProductoRepositorio2(ISession session)
        {
            _session = session;
        }

        public Task<IEnumerable<Producto>> TraerTodosAsync()
        {
            return _session.Query<Producto>()
                .ToListAsync()
                .ContinueWith(IEnumerable<Producto> (task) => task.Result);
        }

        public Task<IEnumerable<Producto>> TraerTodosPorFiltro(string? nombre, int? stock, decimal? precio)
        {
            var query = _session.Query<Producto>().AsQueryable();

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
            return _session.SaveOrUpdateAsync(producto);

        }

        public async Task Baja(int productoId)
        {
            var producto = await _session.GetAsync<Producto>(productoId);
            if (producto == null)
            {
                throw new KeyNotFoundException($"Producto con ID {productoId} no encontrado.");
            }
            await _session.DeleteAsync(producto);
            await _session.FlushAsync();
        }

        public async Task Modificacion(Producto producto)
        {
            if (producto == null)
            {
                throw new ArgumentNullException(nameof(producto), "El producto no puede ser nulo.");
            }
            var existingProducto = await _session.GetAsync<Producto>(producto.ProductoID);
            if (existingProducto == null)
            {
                throw new KeyNotFoundException($"Producto con ID {producto.ProductoID} no encontrado.");
            }
            existingProducto.Nombre = producto.Nombre;
            existingProducto.Stock = producto.Stock;
            existingProducto.Precio = producto.Precio;
            existingProducto.Descripcion = producto.Descripcion;
            await _session.SaveOrUpdateAsync(existingProducto);
            await _session.FlushAsync();
        }
    }
}
