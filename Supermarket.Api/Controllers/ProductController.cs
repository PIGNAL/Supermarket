using MediatR;
using Microsoft.AspNetCore.Mvc;
using Supermarket.Api.Commands.Requests;
using Supermarket.Api.Enums;
using Supermarket.Api.Queries.Requests;
using Supermarket.Domain.Entities;

namespace Supermarket.Api.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAll([FromQuery] OrmType ormType)
        {
            var query = new ProductGetQueryRequest(ormType);
            var results = await _mediator.Send(query);
            return Ok(results);
        }

        /// <summary>
        /// Gets all products filtered by optional parameters.
        /// </summary>
        /// <param name="name">Product name to filter (optional).</param>
        /// <param name="stock">Stock to filter (optional).</param>
        /// <param name="price">Price to filter (optional).</param>
        /// <returns>List of filtered products.</returns>
        /// <response code="200">Returns the filtered list of products.</response>
        [HttpGet("filter")]
        [ProducesResponseType(typeof(IEnumerable<Product>), 200)]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllByFilter(
            [FromQuery] OrmType ormType,
            [FromQuery] string? name,
            [FromQuery] int? stock,
            [FromQuery] decimal? price)
        {
            var query = new ProductGetByFilterQueryRequest(ormType, name, stock, price);
            var results = await _mediator.Send(query);
            return Ok(results);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromQuery] OrmType ormType, [FromBody] Product? product)
        {
            if (product == null)
            {
                return BadRequest("Product cannot be null.");
            }

            var command = new ProductCreateCommandRequest(ormType, product);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{productId:int}")]
        public async Task<ActionResult> Delete([FromQuery] OrmType ormType, int productId)
        {
            try
            {
                var command = new ProductDeleteCommandRequest(ormType, productId);
                var result = await _mediator.Send(command);

                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromQuery] OrmType ormType, [FromBody] Product? product)
        {
            if (product == null)
            {
                return BadRequest("Product cannot be null.");
            }
            var command = new ProductUpdateCommandRequest(ormType, product);
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
