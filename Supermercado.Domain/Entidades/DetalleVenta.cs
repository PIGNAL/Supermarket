namespace Supermercado.Domain.Entidades
{
    public class DetalleVenta
    {
        public int VentaID { get; set; }
        public int ProductoID { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public virtual Producto? Producto { get; set; }
    }
}
