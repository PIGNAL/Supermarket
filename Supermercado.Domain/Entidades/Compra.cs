namespace Supermercado.Domain.Entidades
{
    public class Compra
    {
        public virtual int CompraID { get; set; }
        public virtual DateTime Fecha { get; set; }
        public virtual int? ProveedorID { get; set; }
        public virtual decimal? Total { get; set; }
        public virtual Proveedor? Proveedor { get; set; }
        public virtual ICollection<DetalleCompra> Detalles { get; set; } = new List<DetalleCompra>();
    }
}
