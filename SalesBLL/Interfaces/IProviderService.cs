using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesBLL.DTO;

namespace SalesBLL.Interfaces
{
    public interface IProviderService: IDisposable
    {
        IEnumerable<ProviderDTO> GetProviders(CategoryDTO category);
        void Dispose();
    }
}
