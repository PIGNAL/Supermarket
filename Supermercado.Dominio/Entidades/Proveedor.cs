namespace Supermercado.Dominio.Entidades
{
    public class Proveedor
    {
        public int ProveedorID { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Contacto { get; set; }
        public string? Direccion { get; set; }
        public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
        public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();
    }
}
