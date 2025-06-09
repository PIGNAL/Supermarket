using FluentNHibernate.Mapping;
using Supermarket.Domain.Entities;

namespace Supermarket.Data.NHibernate.Mappers;

public class PurchaseDetailMap : ClassMap<PurchaseDetail>
{
    public PurchaseDetailMap()
    {
        Table("PurchaseDetail");
        CompositeId()
        .KeyProperty(pd => pd.PurchaseId, "PurchaseId")
        .KeyProperty(pd => pd.ProductId, "ProductId");
        Map(pd => pd.Quantity);
        Map(pd => pd.UnitPrice);
        References(pd => pd.Purchase).Not.Nullable();
        References(pd => pd.Product).Not.Nullable();
    }
}