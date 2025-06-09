using Supermarket.Domain.Common;

namespace Supermarket.Domain.Entities
{
    public class Client : BaseDomainModel
    {
        public virtual string Name { get; set; } = string.Empty;
        public virtual string? Address { get; set; }
        public virtual string? Phone { get; set; }
    }
}
