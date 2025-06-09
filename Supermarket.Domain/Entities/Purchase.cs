using Supermarket.Domain.Common;

namespace Supermarket.Domain.Entities
{
    public class Purchase : BaseDomainModel
    {
        public virtual DateTime Date { get; set; }
        public virtual int? SupplierId { get; set; }
        public virtual decimal? Total { get; set; }
        public virtual Supplier? Supplier { get; set; }
        public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; } = new List<PurchaseDetail>();
    }
}
