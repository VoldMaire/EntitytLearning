using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesADODAL.Gateways;
using SalesADODAL.Interfaces;
using SalesADODAL.Models;

namespace SalesADODAL.Repositories
{
    public class ProviderRepository : IRepository<Provider>
    {
        public ProviderRepository(string connectionString)
        {
            Gateway.ConnectionString = connectionString;
        }

        public void Create(Provider item)
        {
            ProvidersGateway.Save(item);
        }

        public void Delete(int id)
        {
            ProvidersGateway.Delete(id);
        }

        public Provider Get(int id)
        {
            return ProvidersGateway.Get(id);
        }

        public IEnumerable<Provider> GetAll()
        {
            return ProvidersGateway.GetAll();
        }

        public void Update(Provider item)
        {
            ProvidersGateway.Save(item);
        }
    }
}
