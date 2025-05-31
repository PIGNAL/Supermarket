using Microsoft.EntityFrameworkCore;
using Supermercado.Domain.Entidades;
using Supermercado.Domain.Repositorios.Interfaces;

namespace Supermercado.Data.Repositorios
{
    public class VentaRepositorio : IVentaRepositorio
    {
        private readonly SupermercadoDbContext _context;
        public VentaRepositorio(SupermercadoDbContext context)
        {
            _context = context;
        }
        public Task Alta(Venta venta)
        {
            if (venta == null)
            {
                throw new ArgumentNullException(nameof(venta), "La venta no puede ser nulo.");
            }
            _context.Ventas.Add(venta);
            return _context.SaveChangesAsync();
        }

        public Task<IEnumerable<Venta>> ConsultarVentasPorArticuloYCliente(int clienteId, int productoId)
        {
            return _context.Ventas.Where(v => v.ClienteID == clienteId && v.Detalles.FirstOrDefault(dv => dv.ProductoID == productoId) != null)
                .Include(v => v.Detalles)
                .ToListAsync()
                .ContinueWith(IEnumerable<Venta> (task) => task.Result);
        }
    }
}
