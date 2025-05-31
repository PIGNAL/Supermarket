namespace Supermercado.Domain.Entidades
{
    public class DetalleCompra
    {
        public int CompraID { get; set; }
        public int ProductoID { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public virtual Compra? Compra { get; set; }
        public virtual Producto? Producto { get; set; }
    }
}
