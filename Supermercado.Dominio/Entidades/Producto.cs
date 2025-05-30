namespace Supermercado.Dominio.Entidades
{
    public class Producto
    {
        public int ProductoID { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public int? ProveedorID { get; set; }
        public virtual Proveedor? Proveedor { get; set; }
    }
}
