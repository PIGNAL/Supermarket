using Supermercado.Domain.Entidades;

namespace Supermercado.Domain.Repositorios.Interfaces;

public interface IVentaRepositorio
{
    Task Alta(Venta venta);

    Task<IEnumerable<Venta>> ConsultarVentasPorArticuloYCliente(int clienteId, int productoId);
}
    