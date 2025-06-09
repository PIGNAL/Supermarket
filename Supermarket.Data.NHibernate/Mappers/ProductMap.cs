using FluentNHibernate.Mapping;
using Supermarket.Domain.Entities;

namespace Supermarket.Data.NHibernate.Mappers
{
    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Table("Products");
            Id(p => p.Id).GeneratedBy.Identity();
            Map(p => p.Name);
            Map(p => p.Description);
            Map(p => p.Price);
            Map(p => p.Stock);
            Map(p => p.SupplierId);
        }
    }
}
