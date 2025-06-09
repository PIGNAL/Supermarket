using FluentNHibernate.Mapping;
using Supermarket.Domain.Entities;

namespace Supermarket.Data.NHibernate.Mappers;

public class SupplierMap : ClassMap<Supplier>
{
    public SupplierMap()
    {
        Table("Supplier");
        Id(s => s.Id).GeneratedBy.Identity();
        Map(s => s.Name).Not.Nullable();
        Map(s => s.Contact).Nullable();
        Map(s => s.Address).Nullable();
        HasMany(s => s.Products).Inverse().Cascade.All();
        HasMany(s => s.Purchases).Inverse().Cascade.All();
    }
}