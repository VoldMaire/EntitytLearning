using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SalesEntityDAL.Contex
{
    class ProductsInitializer: DropCreateDatabaseAlways<ProductsContext>
    {
        protected override void Seed(ProductsContext context)
        {
            Category cat1 = new Category { Name = "Phone" };
            Category cat2 = new Category { Name = "Computer" };
            Category cat3 = new Category { Name = "Socks" };
            Category cat4 = new Category { Name = "Glasses" };
            context.Categories.AddRange(new List<Category> { cat1, cat2, cat3, cat4 });

            Provider prov1 = new Provider { Name = "Samsung", City = "Seul" };
            Provider prov2 = new Provider { Name = "LG", City = "Seul" };
            Provider prov3 = new Provider { Name = "Apple", City = "Los-Angeles" };
            Provider prov4 = new Provider { Name = "Nokia", City = "Gelsinki" };
            Provider prov5 = new Provider { Name = "Gabana", City = "Paris" };
            Provider prov6 = new Provider { Name = "Abibas", City = "New-York" };
            Provider prov7 = new Provider { Name = "Nike", City = "Seul" };
            Provider prov8 = new Provider { Name = "Jitomirskie", City = "Kiev" };
            Provider prov9 = new Provider { Name = "Asus", City = "Pekin" };
            context.Providers.AddRange(new List<Provider> { prov1, prov2, prov3, prov4, prov5, prov6, prov7, prov8, prov9 });

            Product prod1 = new Product { Name = "k56cb", Provider = prov9, Category = cat2, Price = 1000 };
            Product prod2 = new Product { Name = "k55lb", Provider = prov9, Category = cat2, Price = 1100 };
            Product prod3 = new Product { Name = "Macbook Pro", Provider = prov3, Category = cat2, Price = 10000 };
            Product prod4 = new Product { Name = "Macbook Air", Provider = prov3, Category = cat2, Price = 9000 };
            Product prod5 = new Product { Name = "Black Jito", Provider = prov8, Category = cat3, Price = 10 };
            Product prod6 = new Product { Name = "Safe Secure Legs", Provider = prov8, Category = cat3, Price = 11 };
            Product prod7 = new Product { Name = "Run Is Life", Provider = prov7, Category = cat3, Price = 100 };
            Product prod8 = new Product { Name = "Unsmelled Abiba", Provider = prov6, Category = cat3, Price = 50 };
            Product prod9 = new Product { Name = "Run Is Life", Provider = prov7, Category = cat3, Price = 100 };
            Product prod10 = new Product { Name = "Sun kills your eyes", Provider = prov5, Category = cat4, Price = 999 };
            Product prod11 = new Product { Name = "Spirit", Provider = prov2, Category = cat1, Price = 800 };
            Product prod12 = new Product { Name = "Galaxy in your code S", Provider = prov1, Category = cat1, Price = 900 };
            Product prod13 = new Product { Name = "Iphone 66", Provider = prov3, Category = cat1, Price = 666 };
            context.Products.AddRange(new List<Product> { prod1, prod2, prod3, prod4, prod5, prod6, prod7, prod8, prod9, prod10, prod11, prod12, prod13 });
            context.SaveChanges();
        }
    }
}
