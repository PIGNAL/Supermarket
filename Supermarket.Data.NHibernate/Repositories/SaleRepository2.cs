using NHibernate;
using NHibernate.Linq;
using Supermarket.Domain.Entities;
using Supermarket.Domain.Repositories.Interfaces;

namespace Supermarket.Data.NHibernate.Repositories
{
    public class SaleRepository2 : ISaleRepository
    {
        private readonly ISession _session;
        public SaleRepository2(ISession session)
        {
            _session = session;
        }

        public Task Add(Sale? sale)
        {

            if (sale == null)
            {
                throw new ArgumentNullException(nameof(sale), "The sale can't be null.");
            }
            return _session.SaveOrUpdateAsync(sale);
        }

        public Task<IEnumerable<Sale>> GetSalesByProductAndClient(int clientId, int productId)
        {
            return _session.Query<Sale>()
                .Fetch(v => v.Client) 
                .Where(v => v.ClientId == clientId && v.SaleDetails.Any(dv => dv != null && dv.ProductId == productId))
                .ToListAsync()
                .ContinueWith<IEnumerable<Sale>>(task => task.Result);
        }
    }
}
