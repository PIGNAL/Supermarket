using Supermarket.Domain.Common;

namespace Supermarket.Domain.Entities
{
    public class Sale : BaseDomainModel
    {
            public virtual DateTime Date { get; set; }
            public virtual int? ClientId { get; set; }
            public virtual decimal? Total { get; set; }
            public virtual Client? Client { get; set; }
            public virtual ICollection<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();
    }
}
