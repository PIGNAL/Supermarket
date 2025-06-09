using Microsoft.AspNetCore.Mvc;
using Supermarket.Api.Enums;
using Supermarket.Api.Factories;
using Supermarket.Domain.Entities;

namespace Supermarket.Api.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : Controller
    {
        private readonly IProductRepositoryFactory  _repositoryFactory;

        public ProductController(IProductRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll([FromQuery] OrmType ormType)
        {
            var repository = _repositoryFactory.Create(ormType);
            var products = await repository.GetAllAsync();
            return Ok(products);
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
            var repository = _repositoryFactory.Create(ormType);
            var products = await repository.GetAllByFilterAsync(name, stock, price);
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromQuery] OrmType ormType, [FromBody] Product? product)
        {
            if (product == null)
            {
                return BadRequest("Product cannot be null.");
            }
            var repository = _repositoryFactory.Create(ormType);
            await repository.AddAsync(product);
            return Ok();
        }

        [HttpDelete("{productId}")]
        public async Task<ActionResult> Delete([FromQuery] OrmType ormType, int productId)
        {
            try
            {
                var repository = _repositoryFactory.Create(ormType);
                await repository.DeleteAsync(productId);
                return Ok();
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
            var repository = _repositoryFactory.Create(ormType);

            await repository.UpdateAsync(product);
            return Ok();
        }
    }
}
