using MediatR;
using Supermarket.Api.Enums;
using Supermarket.Domain.Entities;

namespace Supermarket.Api.Queries.Requests
{
    public class ProductGetQueryRequest : IRequest<List<Product>>
    {
        public ProductGetQueryRequest(OrmType ormType)
        {
            OrmType = ormType;
        }

        public OrmType OrmType { get; set; }

        
    }
}
