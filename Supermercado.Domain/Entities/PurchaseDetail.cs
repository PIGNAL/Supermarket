namespace Supermarket.Domain.Entities
{
    public class PurchaseDetail
    {
        public virtual int PurchaseId { get; set; }
        public virtual int ProductId { get; set; }
        public virtual int Quantity { get; set; }
        public virtual decimal UnitPrice { get; set; }
        public virtual Purchase? Purchase { get; set; }
        public virtual Product? Product { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is not PurchaseDetail other)
                return false;
            return PurchaseId == other.PurchaseId && ProductId == other.ProductId;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + PurchaseId.GetHashCode();
                hash = hash * 23 + ProductId.GetHashCode();
                return hash;
            }
        }
    }
}
