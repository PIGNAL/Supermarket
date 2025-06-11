using MediatR;
using Supermarket.Api.Enums;
using Supermarket.Domain.Entities;

namespace Supermarket.Api.Commands.Requests
{
    public class SaleCreateCommandRequest : IRequest<bool>
    {
        public SaleCreateCommandRequest(OrmType ormType, Sale sale)
        {
            OrmType = ormType;
            Sale = sale;
        }
        public OrmType OrmType { get; set; }
        public Sale Sale { get; set; }
    }
}
