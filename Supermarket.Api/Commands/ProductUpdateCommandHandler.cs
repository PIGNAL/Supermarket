using MediatR;
using Supermarket.Api.Commands.Requests;
using Supermarket.Api.Factories;

namespace Supermarket.Api.Commands
{
    public class ProductUpdateCommandHandler: IRequestHandler<ProductUpdateCommandRequest, bool>
    {
        private readonly IProductRepositoryFactory _productRepositoryFactory;
        public ProductUpdateCommandHandler(IProductRepositoryFactory productRepositoryFactory)
        {
            _productRepositoryFactory = productRepositoryFactory;
        }

        public Task<bool> Handle(ProductUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            var repository = _productRepositoryFactory.Create(request.OrmType);
            return repository.UpdateAsync(request.Product)
                .ContinueWith(task => task.IsCompletedSuccessfully, cancellationToken);
        }
    }
}
