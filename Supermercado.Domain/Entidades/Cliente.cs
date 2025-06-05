namespace Supermercado.Domain.Entidades
{
    public class Cliente 
    {
        public virtual int ClienteID { get; set; }
        public virtual string Nombre { get; set; } = string.Empty;
        public virtual string? Direccion { get; set; }
        public virtual string? Telefono { get; set; }
        
    }
}
