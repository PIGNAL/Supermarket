using MediatR;
using Supermarket.Api.Enums;

namespace Supermarket.Api.Commands.Requests
{
    public class ProductDeleteCommandRequest : IRequest<bool>
    {
        public ProductDeleteCommandRequest(OrmType ormType, int productId)
        {
            OrmType = ormType;
            ProductId = productId;
        }
        public OrmType OrmType { get; set; }
        public int ProductId { get; set; }
    }
}
