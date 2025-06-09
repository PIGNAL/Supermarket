using FluentNHibernate.Mapping;
using Supermarket.Domain.Entities;

namespace Supermarket.Data.NHibernate.Mappers;

public class SaleDetailMap : ClassMap<SaleDetail>
{
    public SaleDetailMap()
    {
        Table("SaleDetail");
        CompositeId()
            .KeyProperty(sd => sd.SaleId, "SaleId")
            .KeyProperty(sd => sd.ProductId, "ProductId");
        Map(sd => sd.Quantity);
        Map(sd => sd.UnitPrice);
    }
}