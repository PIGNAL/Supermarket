

using Supermercado.Domain.Entidades;

namespace Supermercado.Domain.Repositorios.Interfaces
{
    public interface IProductoRepositorio
    {
        public Task<IEnumerable<Producto>> TraerTodosAsync();

        public Task<IEnumerable<Producto>> TraerTodosPorFiltro(string? nombre, int? stock, decimal? precio);

        public Task Alta(Producto producto);
        public Task Baja(int productoId);
        public Task Modificacion(Producto producto);

    }
}
