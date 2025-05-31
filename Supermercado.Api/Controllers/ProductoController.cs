using Microsoft.AspNetCore.Mvc;
using Supermercado.Domain.Entidades;
using Supermercado.Domain.Repositorios.Interfaces;

namespace Supermercado.Api.Controllers
{
    [ApiController]
    [Route("api/productos")]
    public class ProductoController : Controller
    {
        private readonly IProductoRepositorio _productoRepositorio;

        public ProductoController(IProductoRepositorio productoRepositorio)
        {
            _productoRepositorio = productoRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> TraerTodos()
        {
            var query = await _productoRepositorio.TraerTodosAsync();
            return Ok(query);
        }

        /// <summary>
        /// Gets all products filtered by optional parameters.
        /// </summary>
        /// <param name="nombre">Product name to filter (optional).</param>
        /// <param name="stock">Stock to filter (optional).</param>
        /// <param name="precio">Price to filter (optional).</param>
        /// <returns>List of filtered products.</returns>
        /// <response code="200">Returns the filtered list of products.</response>
        [HttpGet("filtro")]
        [ProducesResponseType(typeof(IEnumerable<Producto>), 200)]
        public async Task<ActionResult<IEnumerable<Producto>>> TraerTodosPorFiltro(
            [FromQuery] string? nombre,
            [FromQuery] int? stock,
            [FromQuery] decimal? precio)
        {
            var query = await _productoRepositorio.TraerTodosPorFiltro(nombre, stock, precio);
            return Ok(query);
        }

        [HttpPost]
        public async Task<ActionResult> Alta([FromBody] Producto producto)
        {
            if (producto == null)
            {
                return BadRequest("El producto no puede ser nulo.");
            }

            await _productoRepositorio.Alta(producto);
            return Ok();
        }

        [HttpDelete("{productoId}")]
        public async Task<ActionResult> Baja(int productoId)
        {
            try
            {
                await _productoRepositorio.Baja(productoId);
                return Ok();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Modificacion([FromBody] Producto producto)
        {
            if (producto == null)
            {
                return BadRequest("El producto no puede ser nulo.");
            }

            await _productoRepositorio.Modificacion(producto);
            return Ok();

        }
    }
}
