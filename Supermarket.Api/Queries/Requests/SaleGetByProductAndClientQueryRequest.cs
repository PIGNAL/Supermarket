using MediatR;
using Supermarket.Api.Enums;
using Supermarket.Domain.Entities;

namespace Supermarket.Api.Queries.Requests
{
    public class SaleGetByProductAndClientQueryRequest: IRequest<List<Sale>>
    {
        public SaleGetByProductAndClientQueryRequest(OrmType ormType,int productId, int clientId)
        {
            OrmType = ormType;
            ProductId = productId;
            ClientId = clientId;
        }
        public OrmType OrmType { get; set; }
        public int ProductId { get; set; }
        public int ClientId { get; set; }
    }
}
