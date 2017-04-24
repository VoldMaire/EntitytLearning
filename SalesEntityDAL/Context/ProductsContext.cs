using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SalesEntityDAL
{
    public class ProductsContext: DbContext
    {
        public ProductsContext()
        {}

        public ProductsContext(string connString):
            base(connString)
        {}

        static ProductsContext()
        {
            Database.SetInitializer<ProductsContext>(new Context.ProductsInitializer());
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Provider> Providers { get; set; }
    }
}

