using FluentNHibernate.Mapping;
using Supermarket.Domain.Entities;

namespace Supermarket.Data.NHibernate.Mappers;

public class PurchaseMap : ClassMap<Purchase>
{
    public PurchaseMap()
    {
        Table("Purchases");
        Id(p => p.Id).GeneratedBy.Identity();
        Map(p => p.Date);
        Map(p => p.SupplierId);
        Map(p => p.Total);
        HasMany(p => p.PurchaseDetails).Inverse().Cascade.All();
    }
}