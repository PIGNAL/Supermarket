using NHibernate;
using NHibernate.Linq;
using Supermercado.Domain.Entidades;
using Supermercado.Domain.Repositorios.Interfaces;

namespace Supermercado.Data2.Repositorios
{
    public class VentaRepositorio2 : IVentaRepositorio
    {
        private readonly ISession _session;
        public VentaRepositorio2(ISession session)
        {
            _session = session;
        }
        public Task Alta(Venta venta)
        {
            if (venta == null)
            {
                throw new ArgumentNullException(nameof(venta), "La venta no puede ser nulo.");
            }
            return _session.SaveOrUpdateAsync(venta);

        }

        public Task<IEnumerable<Venta>> ConsultarVentasPorArticuloYCliente(int clienteId, int productoId)
        {
            return _session.Query<Venta>()
                .Fetch(v => v.Cliente) // Incluye la propiedad virtual Cliente
                .Where(v => v.ClienteID == clienteId && v.Detalles.Any(dv => dv != null && dv.ProductoID == productoId))
                .ToListAsync()
                .ContinueWith<IEnumerable<Venta>>(task => task.Result);
        }
    }
}
