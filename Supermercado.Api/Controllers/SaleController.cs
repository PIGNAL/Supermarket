using Microsoft.AspNetCore.Mvc;
using Supermarket.Domain.Entities;
using Supermarket.Domain.Repositories.Interfaces;

namespace Supermarket.Api.Controllers
{
    [ApiController]
    [Route("api/sales")]
    public class SaleController : Controller
    {
        private readonly ISaleRepository _saleRepository;

        public SaleController(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] Sale? sale)
        {
            if (sale == null)
            {
                return BadRequest("La sale no puede ser nula.");
            }

            await _saleRepository.Add(sale);
            return Ok();
        }

        [HttpGet("filter")]
        [ProducesResponseType(typeof(IEnumerable<Sale>), 200)]
        public async Task<ActionResult<IEnumerable<Sale>>> GetSalesByProductAndClient([FromQuery] int clientId,
            [FromQuery] int productId)
        {
            var query = await _saleRepository.GetSalesByProductAndClient(clientId, productId);
            return Ok(query);
        }
    }
}
