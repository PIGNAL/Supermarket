using NHibernate;
using NHibernate.Linq;
using Supermarket.Domain.Entities;
using Supermarket.Domain.Repositories.Interfaces;

namespace Supermarket.Data.NHibernate.Repositories
{
    public class SaleRepositoryNhibernate : ISaleRepository
    {
        private readonly ISession _session;
        public SaleRepositoryNhibernate(ISession session)
        {
            _session = session;
        }

        public Task AddAsync(Sale? sale)
        {

            if (sale == null)
            {
                throw new ArgumentNullException(nameof(sale), "The sale can't be null.");
            }
            return _session.SaveOrUpdateAsync(sale);
        }

        public Task<IEnumerable<Sale>> GetSalesByProductAndClientAsync(int clientId, int productId)
        {
            return _session.Query<Sale>()
                .Fetch(v => v.Client) 
                .Where(v => v.ClientId == clientId && v.SaleDetails.Any(dv => dv != null && dv.ProductId == productId))
                .ToListAsync()
                .ContinueWith<IEnumerable<Sale>>(task => task.Result);
        }
    }
}
