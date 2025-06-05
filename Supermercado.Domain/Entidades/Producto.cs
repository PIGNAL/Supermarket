namespace Supermercado.Domain.Entidades
{
    public class Producto
    {
        public virtual int ProductoID { get; set; }
        public virtual string Nombre { get; set; } = string.Empty;
        public virtual string? Descripcion { get; set; }
        public virtual decimal Precio { get; set; }
        public virtual int Stock { get; set; }
        public virtual int? ProveedorID { get; set; }
        public virtual Proveedor? Proveedor { get; set; }
    }
}
