using MediatR;
using Supermarket.Api.Enums;
using Supermarket.Domain.Entities;

namespace Supermarket.Api.Queries.Requests
{
    public class ProductGetByFilterQueryRequest : IRequest<List<Product>>
    {
        public ProductGetByFilterQueryRequest(OrmType ormType,string? name, int? stock, decimal? price)
        {
            OrmType = ormType;
            Name = name;
            Stock = stock;
            Price = price;
        }
        public OrmType OrmType { get; set; }
        public string? Name { get; set; }
        public int? Stock { get; set; }
        public decimal? Price { get; set; }
    }
}
