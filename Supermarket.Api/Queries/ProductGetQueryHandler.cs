using MediatR;
using Supermarket.Api.Factories;
using Supermarket.Api.Queries.Requests;
using Supermarket.Domain.Entities;

namespace Supermarket.Api.Queries
{
    public class ProductGetQueryHandler: IRequestHandler<ProductGetQueryRequest, List<Product>>

    {
        private readonly IProductRepositoryFactory _productRepositoryFactory;
        public ProductGetQueryHandler(IProductRepositoryFactory productRepositoryFactory)
        {
            _productRepositoryFactory = productRepositoryFactory;
        }

        public Task<List<Product>> Handle(ProductGetQueryRequest request, CancellationToken cancellationToken)
        {
            var repository = _productRepositoryFactory.Create(request.OrmType);
            return repository.GetAllAsync().ContinueWith(task => task.Result.ToList(), cancellationToken);
        }
    }
}
