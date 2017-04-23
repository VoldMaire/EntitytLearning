using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesBLL.DTO;

namespace SalesBLL.Interfaces
{
    public interface IProductService: IDisposable
    {
        IEnumerable<ProductDTO> GetProducts(CategoryDTO category);
        IEnumerable<ProductDTO> GetProducts(ProviderDTO provider);
        void Dispose();
    }
}
