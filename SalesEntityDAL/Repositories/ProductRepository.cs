using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesEntityDAL
{
    public class ProductRepository : IRepository<Product>
    {
        private ProductsContext _context;

        public ProductRepository(ProductsContext context)
        {
            _context = context;
        }

        public void Create(Product item)
        {
            _context.Products.Add(item);
        }

        public void Delete(int id)
        {
            Product product = _context.Products.Find(id);
            if (product != null)
                _context.Products.Remove(product);
        }

        public Product Get(int id)
        {
            return _context.Products.Find(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products;
        }

        public void Update(Product item)
        {
            _context.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
