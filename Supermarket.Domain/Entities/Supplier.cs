using Supermarket.Domain.Common;

namespace Supermarket.Domain.Entities
{
    public class Supplier : BaseDomainModel
    {
        public virtual string Name { get; set; } = string.Empty;
        public virtual string? Contact { get; set; }
        public virtual string? Address { get; set; }
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
        public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
    }
}
