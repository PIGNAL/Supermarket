using MediatR;
using Microsoft.AspNetCore.Mvc;
using Supermarket.Api.Commands.Requests;
using Supermarket.Api.Enums;
using Supermarket.Api.Queries.Requests;
using Supermarket.Domain.Entities;

namespace Supermarket.Api.Controllers
{
    [ApiController]
    [Route("api/sales")]
    public class SaleController : Controller
    {
        private readonly IMediator _mediator;

        public SaleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromQuery] OrmType ormType, [FromBody] Sale? sale)
        {
            if (sale == null)
            {
                return BadRequest("La sale can't be null.");
            }
            var command = new SaleCreateCommandRequest(ormType, sale);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("filter")]
        [ProducesResponseType(typeof(IEnumerable<Sale>), 200)]
        public async Task<ActionResult<IEnumerable<Sale>>> GetSalesByProductAndClient([FromQuery] OrmType ormType, [FromQuery] int clientId,
            [FromQuery] int productId)
        {
            var query = new SaleGetByProductAndClientQueryRequest(ormType, clientId, productId);
            var results = await _mediator.Send(query);
            return Ok(results);
        }
    }
}
