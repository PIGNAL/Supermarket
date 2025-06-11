using MediatR;
using Supermarket.Api.Enums;
using Supermarket.Domain.Entities;

namespace Supermarket.Api.Commands.Requests
{
    public class ProductCreateCommandRequest : IRequest<bool>
    {
        public ProductCreateCommandRequest(OrmType ormType, Product product)
        {
            OrmType = ormType;
            Product = product;
        }

        public OrmType OrmType { get; set; }
        public Product Product { get; set; }
    }
}
