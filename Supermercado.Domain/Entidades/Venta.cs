namespace Supermercado.Domain.Entidades
{
    public class Venta
    {
        public virtual int VentaID { get; set; }
        public virtual DateTime Fecha { get; set; }
        public virtual int? ClienteID { get; set; }
        public virtual decimal? Total { get; set; }
        public virtual Cliente? Cliente { get; set; }
        public virtual ICollection<DetalleVenta> Detalles { get; set; } = new List<DetalleVenta>();
    }
}
