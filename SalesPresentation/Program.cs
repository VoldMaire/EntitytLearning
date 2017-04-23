using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesBLL.DTO;
using SalesBLL.Interfaces;
using SalesBLL;

namespace SalesPresentation
{
    class Program
    {

        static void Main(string[] args)
        {
            using (ProductService prodServ = new ProductService())
            {
                foreach (var cat in prodServ.GetCategories())
                {
                    foreach (var prod in prodServ.GetProducts(cat))
                    {
                        Console.WriteLine(prod.Name);
                    }
                    using (ProviderService provServ = new ProviderService())
                    {
                        foreach (var prov in provServ.GetProviders(cat))
                        {
                            Console.WriteLine(prov.Name);
                        }
                    }
                    Console.ReadLine();
                }
                using (ProviderService provServ = new ProviderService())
                {
                    foreach (var prov in provServ.GetProvidersByCity("Seul"))
                    {
                        Console.WriteLine("City of {0} is {1}", prov.Name, prov.City);
                    }
                }
                foreach (var prod in prodServ.GetProductsCheaper(700))
                {
                    Console.WriteLine("Product {0} cost {1}", prod.Name, prod.Price);
                }
                Console.ReadLine();
            }
        }
    }
}

