using MediatR;
using Supermarket.Api.Factories;
using Supermarket.Api.Queries.Requests;
using Supermarket.Domain.Entities;

namespace Supermarket.Api.Queries
{
    public class ProductGetByFilterQueryHandler: IRequestHandler<ProductGetByFilterQueryRequest, List<Product>>
    {
        private readonly IProductRepositoryFactory _productRepositoryFactory;
        public ProductGetByFilterQueryHandler(IProductRepositoryFactory productRepositoryFactory)
        {
            _productRepositoryFactory = productRepositoryFactory;
        }
        public Task<List<Product>> Handle(ProductGetByFilterQueryRequest request, CancellationToken cancellationToken)
        {
            var repository = _productRepositoryFactory.Create(request.OrmType);
            return repository.GetAllByFilterAsync(request.Name, request.Stock, request.Price)
                .ContinueWith(task => task.Result.ToList(), cancellationToken);
        }
    }
}
