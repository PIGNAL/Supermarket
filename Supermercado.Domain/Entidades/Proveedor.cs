namespace Supermercado.Domain.Entidades
{
    public class Proveedor
    {
        public virtual int ProveedorID { get; set; }
        public virtual string Nombre { get; set; } = string.Empty;
        public virtual string? Contacto { get; set; }
        public virtual string? Direccion { get; set; }
        public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
        public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();
    }
}
