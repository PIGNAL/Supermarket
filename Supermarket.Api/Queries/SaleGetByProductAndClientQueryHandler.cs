using MediatR;
using Supermarket.Api.Factories;
using Supermarket.Api.Queries.Requests;
using Supermarket.Domain.Entities;

namespace Supermarket.Api.Queries
{
    public class SaleGetByProductAndClientQueryHandler:IRequestHandler<SaleGetByProductAndClientQueryRequest, List<Sale>>
    {
        private readonly ISaleRepositoryFactory _saleRepositoryFactory;
        public SaleGetByProductAndClientQueryHandler(ISaleRepositoryFactory saleRepositoryFactory)
        {
            _saleRepositoryFactory = saleRepositoryFactory;
        }
        public Task<List<Sale>> Handle(SaleGetByProductAndClientQueryRequest request, CancellationToken cancellationToken)
        {
            var repository = _saleRepositoryFactory.Create(request.OrmType);
            return repository.GetSalesByProductAndClientAsync(request.ProductId, request.ClientId)
                .ContinueWith(task => task.Result.ToList(), cancellationToken);
        }
    }
}
