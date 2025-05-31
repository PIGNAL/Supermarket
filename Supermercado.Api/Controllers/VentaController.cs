using Microsoft.AspNetCore.Mvc;
using Supermercado.Data.Repositorios;
using Supermercado.Domain.Entidades;
using Supermercado.Domain.Repositorios.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Supermercado.Api.Controllers
{
    [ApiController]
    [Route("api/ventas")]
    public class VentaController : Controller
    {
        private readonly IVentaRepositorio _ventaRepositorio;

        public VentaController(IVentaRepositorio ventaRepositorio)
        {
            _ventaRepositorio = ventaRepositorio;
        }

        [HttpPost]
        public async Task<ActionResult> Alta([FromBody] Venta venta)
        {
            if (venta == null)
            {
                return BadRequest("La venta no puede ser nula.");
            }

            await _ventaRepositorio.Alta(venta);
            return Ok();
        }

        [HttpGet("filtro")]
        [ProducesResponseType(typeof(IEnumerable<Venta>), 200)]
        public async Task<ActionResult<IEnumerable<Venta>>> ConsultarVentasPorArticuloYCliente([FromQuery] int clienteId,
            [FromQuery] int productoId)
        {
            var query = await _ventaRepositorio.ConsultarVentasPorArticuloYCliente(clienteId, productoId);
            return Ok(query);
        }
    }
}
