namespace Supermercado.Domain.Entidades
{
    public class DetalleCompra
    {
        public virtual int CompraID { get; set; }
        public virtual int ProductoID { get; set; }
        public virtual int Cantidad { get; set; }
        public virtual decimal PrecioUnitario { get; set; }
        public virtual Compra? Compra { get; set; }
        public virtual Producto? Producto { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is not DetalleCompra other)
                return false;
            return CompraID == other.CompraID && ProductoID == other.ProductoID;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + CompraID.GetHashCode();
                hash = hash * 23 + ProductoID.GetHashCode();
                return hash;
            }
        }
    }

}
