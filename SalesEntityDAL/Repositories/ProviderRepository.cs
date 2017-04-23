using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesEntityDAL
{
    public class ProviderRepository : IRepository<Provider>
    {
        private ProductsContext _context;

        public ProviderRepository(ProductsContext context)
        {
            _context = context;
        }

        public void Create(Provider item)
        {
            _context.Providers.Add(item);
        }

        public void Delete(int id)
        {
            Provider provider = _context.Providers.Find(id);
            if (provider != null)
                _context.Providers.Remove(provider);
        }

        public Provider Get(int id)
        {
            return _context.Providers.Find(id);
        }

        public IEnumerable<Provider> GetAll()
        {
            return _context.Providers;
        }

        public void Update(Provider item)
        {
            _context.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
