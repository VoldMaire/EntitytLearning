using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesEntityDAL
{
    public interface IUnitOfWork: IDisposable
    {
        IRepository<Category> Categories { get;}
        IRepository<Product> Products { get; }
        IRepository<Provider> Providers { get; }
        void Save();
    }
}
