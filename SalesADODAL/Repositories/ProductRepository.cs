using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesADODAL.Interfaces;
using SalesADODAL.Gateways;
using SalesADODAL.Models;

namespace SalesADODAL.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        public ProductRepository(string connectionString)
        {
            Gateway.ConnectionString = connectionString;
        }

        public void Create(Product item)
        {
            ProductsGateway.Save(item);
        }

        public void Delete(int id)
        {
            ProductsGateway.Delete(id);
        }

        public Product Get(int id)
        {
            return ProductsGateway.Get(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return ProductsGateway.GetAll();
        }

        public void Update(Product item)
        {
            ProductsGateway.Save(item);
        }
    }
}
