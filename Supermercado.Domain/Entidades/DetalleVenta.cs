using System.Text.Json.Serialization;

namespace Supermercado.Domain.Entidades
{
    public class DetalleVenta
    {
        public virtual int VentaID { get; set; }
        public virtual int ProductoID { get; set; }
        public virtual int Cantidad { get; set; }
        public virtual decimal PrecioUnitario { get; set; }
        public virtual Producto? Producto { get; set; }
        [JsonIgnore]
        public virtual Venta? Venta { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is not DetalleVenta other)
                return false;
            return VentaID == other.VentaID && ProductoID == other.ProductoID;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + VentaID.GetHashCode();
                hash = hash * 23 + ProductoID.GetHashCode();
                return hash;
            }
        }
    }
}
