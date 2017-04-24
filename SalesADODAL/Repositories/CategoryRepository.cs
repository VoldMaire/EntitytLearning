using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesADODAL.Interfaces;
using SalesADODAL.Models;
using SalesADODAL.Gateways;

namespace SalesADODAL.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        public CategoryRepository(string connectionString)
        {
            Gateway.ConnectionString = connectionString;
        }

        public void Create(Category item)
        {
            CategoriesGateway.Save(item);
        }

        public void Delete(int id)
        {
            CategoriesGateway.Delete(id);
        }

        public Category Get(int id)
        {
            return CategoriesGateway.Get(id);
        }

        public IEnumerable<Category> GetAll()
        {
            return CategoriesGateway.GetAll();
        }

        public void Update(Category item)
        {
            CategoriesGateway.Save(item);
        }
    }
}
