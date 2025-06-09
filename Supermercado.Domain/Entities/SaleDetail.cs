using System.Text.Json.Serialization;

namespace Supermarket.Domain.Entities
{
    public class SaleDetail
    {
        public virtual int SaleId { get; set; }
        public virtual int ProductId { get; set; }
        public virtual int Quantity { get; set; }
        public virtual decimal UnitPrice { get; set; }
        public virtual Product? Product { get; set; }
        [JsonIgnore]
        public virtual Sale? Sale { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is not SaleDetail other)
                return false;
            return SaleId == other.SaleId && ProductId == other.ProductId;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + SaleId.GetHashCode();
                hash = hash * 23 + ProductId.GetHashCode();
                return hash;
            }
        }
    }
}
