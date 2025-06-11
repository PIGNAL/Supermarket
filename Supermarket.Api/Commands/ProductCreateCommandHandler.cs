using MediatR;
using Supermarket.Api.Commands.Requests;
using Supermarket.Api.Factories;

namespace Supermarket.Api.Commands
{
    public class ProductCreateCommandHandler: IRequestHandler<ProductCreateCommandRequest, bool>
    {
        private readonly IProductRepositoryFactory _productRepositoryFactory;

        public ProductCreateCommandHandler(IProductRepositoryFactory productRepositoryFactory)
        {
            _productRepositoryFactory = productRepositoryFactory;
        }

        public Task<bool> Handle(ProductCreateCommandRequest request, CancellationToken cancellationToken)
        {
            var repository = _productRepositoryFactory.Create(request.OrmType);
            return repository.AddAsync(request.Product)
                .ContinueWith(task => task.IsCompletedSuccessfully, cancellationToken);
        }
    }
}
