using Microsoft.AspNetCore.Mvc;
using Supermarket.Api.Enums;
using Supermarket.Api.Factories;
using Supermarket.Domain.Entities;

namespace Supermarket.Api.Controllers
{
    [ApiController]
    [Route("api/sales")]
    public class SaleController : Controller
    {
        private readonly ISaleRepositoryFactory _saleRepositoryFactory;

        public SaleController(ISaleRepositoryFactory saleRepositoryFactory)
        {
            _saleRepositoryFactory = saleRepositoryFactory;
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromQuery] OrmType ormType, [FromBody] Sale? sale)
        {
            if (sale == null)
            {
                return BadRequest("La sale can't be null.");
            }
            var repository = _saleRepositoryFactory.Create(ormType);
            await repository.Add(sale);
            return Ok();
        }

        [HttpGet("filter")]
        [ProducesResponseType(typeof(IEnumerable<Sale>), 200)]
        public async Task<ActionResult<IEnumerable<Sale>>> GetSalesByProductAndClient([FromQuery] OrmType ormType, [FromQuery] int clientId,
            [FromQuery] int productId)
        {
            var repository = _saleRepositoryFactory.Create(ormType);
            var query = await repository.GetSalesByProductAndClient(clientId, productId);
            return Ok(query);
        }
    }
}
