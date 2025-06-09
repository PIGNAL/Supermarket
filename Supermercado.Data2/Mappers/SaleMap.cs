using FluentNHibernate.Mapping;
using Supermarket.Domain.Entities;

namespace Supermarket.Data.NHibernate.Mappers;

public class SaleMap : ClassMap<Sale>
{
    public SaleMap()
    {
        Table("Sales");
        Id(v => v.Id).GeneratedBy.Identity();
        Map(v => v.Date).Not.Nullable();
        Map(v => v.ClientId).Nullable();
        Map(v => v.Total).Nullable();
        HasMany(c => c.SaleDetails).Inverse().Cascade.All();
        References(d => d.Client).Column("ClientId")
            .Not.Insert()
            .Not.Update();

    }
}