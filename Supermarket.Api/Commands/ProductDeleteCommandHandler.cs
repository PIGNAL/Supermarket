using MediatR;
using Supermarket.Api.Commands.Requests;
using Supermarket.Api.Factories;

namespace Supermarket.Api.Commands
{
    public class ProductDeleteCommandHandler: IRequestHandler<ProductDeleteCommandRequest, bool>
    {
        private readonly IProductRepositoryFactory _productRepositoryFactory;

        public ProductDeleteCommandHandler(IProductRepositoryFactory productRepositoryFactory)
        {
            _productRepositoryFactory = productRepositoryFactory;
        }

        public Task<bool> Handle(ProductDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            var repository = _productRepositoryFactory.Create(request.OrmType);
            return repository.DeleteAsync(request.ProductId)
                .ContinueWith(task => task.IsCompletedSuccessfully, cancellationToken);
        }
    }
}
