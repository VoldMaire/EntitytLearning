using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesADODAL.Interfaces;
using SalesADODAL.Models;
using SalesADODAL.Repositories;

namespace SalesADODAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private string _connectionString;
        private CategoryRepository _categoryRepository;
        private ProductRepository _productRepository;
        private ProviderRepository _providerRepository;

        public UnitOfWork(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IRepository<Category> Categories
        {
            get
            {
                if(_categoryRepository == null)
                {
                    _categoryRepository = new CategoryRepository(_connectionString);
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
                    _productRepository = new ProductRepository(_connectionString);
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
                    _providerRepository = new ProviderRepository(_connectionString);
                }
                return _providerRepository;
            }
        }

        public void Dispose() { }
        public void Save() { }
    }
}
