using Supermarket.Domain.Common;

namespace Supermarket.Domain.Entities
{
    public class Product : BaseDomainModel
    {
        public virtual string Name { get; set; } = string.Empty;
        public virtual string? Description { get; set; }
        public virtual decimal Price { get; set; }
        public virtual int Stock { get; set; }
        public virtual int? SupplierId { get; set; }
        public virtual Supplier? Supplier { get; set; }
    }
}
