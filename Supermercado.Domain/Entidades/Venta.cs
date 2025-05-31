namespace Supermercado.Domain.Entidades
{
    public class Venta
    {
        public int VentaID { get; set; }
        public DateTime Fecha { get; set; }
        public int? ClienteID { get; set; }
        public decimal? Total { get; set; }
        public virtual Cliente? Cliente { get; set; }
        public virtual ICollection<DetalleVenta> Detalles { get; set; } = new List<DetalleVenta>();
    }
}
