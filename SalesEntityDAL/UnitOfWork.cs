using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesEntityDAL
{
    public class UnitOfWork: IUnitOfWork
    {
        private ProductsContext _context = new ProductsContext();
        private CategoryRepository _categoryRepository;
        private ProductRepository _productRepository;
        private ProviderRepository _providerRepository;

        public IRepository<Category> Categories
        {
            get
            {
                if(_categoryRepository == null)
                {
                    _categoryRepository = new CategoryRepository(_context);
                }
                return _categoryRepository;
            }
        }

        public IRepository<Product> Products
        {
            get
            {
                if(_productRepository == null)
                {
                    _productRepository = new ProductRepository(_context);
                }
                return _productRepository;
            }
        }

        public IRepository<Provider> Providers
        {
            get
            {
                if(_providerRepository == null)
                {
                    _providerRepository = new ProviderRepository(_context);
                }
                return _providerRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool _disposed = false;

        public void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
