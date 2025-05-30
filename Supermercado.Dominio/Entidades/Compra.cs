namespace Supermercado.Dominio.Entidades
{
    public class Compra
    {
        public int CompraID { get; set; }
        public DateTime Fecha { get; set; }
        public int? ProveedorID { get; set; }
        public decimal? Total { get; set; }
        public virtual Proveedor? Proveedor { get; set; }
        public virtual ICollection<DetalleCompra> Detalles { get; set; } = new List<DetalleCompra>();
    }
}
