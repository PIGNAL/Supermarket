using MediatR;
using Supermarket.Api.Commands.Requests;
using Supermarket.Api.Factories;

namespace Supermarket.Api.Commands
{
    public class SaleCreateCommandHandler : IRequestHandler<SaleCreateCommandRequest, bool>
    {
        private readonly ISaleRepositoryFactory _saleRepositoryFactory;
        public SaleCreateCommandHandler(ISaleRepositoryFactory saleRepositoryFactory)
        {
            _saleRepositoryFactory = saleRepositoryFactory;
        }
        public Task<bool> Handle(SaleCreateCommandRequest request, CancellationToken cancellationToken)
        {
            var repository = _saleRepositoryFactory.Create(request.OrmType);
            return repository.AddAsync(request.Sale)
                .ContinueWith(task => task.IsCompletedSuccessfully, cancellationToken);
        }
    }
}
