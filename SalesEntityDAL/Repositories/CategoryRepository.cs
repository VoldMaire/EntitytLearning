using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesEntityDAL
{
    public class CategoryRepository : IRepository<Category>
    {
        private ProductsContext _context;

        public CategoryRepository(ProductsContext context)
        {
            _context = context;
        }

        public void Create(Category item)
        {
            _context.Categories.Add(item);
        }

        public void Delete(int id)
        {
            Category category = _context.Categories.Find(id);
            if (category != null)
                _context.Categories.Remove(category);
        }

        public Category Get(int id)
        {
            return _context.Categories.Find(id);
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories;
        }

        public void Update(Category item)
        {
            _context.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
