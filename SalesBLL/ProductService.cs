using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesBLL.DTO;
using SalesBLL.Interfaces;
using SalesEntityDAL;
using AutoMapper;

namespace SalesBLL
{
    public class ProductService : IProductService
    {
        private IUnitOfWork _dataBase;

        public ProductService()
        {
            _dataBase = new UnitOfWork();
        }

        public void Dispose()
        {
            _dataBase.Dispose();
        }

        public IEnumerable<CategoryDTO> GetCategories()
        {
            var resultCategories = _dataBase.Categories.GetAll();
            Mapper.Initialize(cfg => cfg.CreateMap<Category, CategoryDTO>());
            IEnumerable<CategoryDTO> mappedResult = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(resultCategories);
            return mappedResult;
        }

        public IEnumerable<ProviderDTO> GetProviders()
        {
            var resultProviders = _dataBase.Providers.GetAll();
            Mapper.Initialize(cfg => cfg.CreateMap<Category, CategoryDTO>());
            IEnumerable<ProviderDTO> mappedResult = Mapper.Map<IEnumerable<Provider>, IEnumerable<ProviderDTO>>(resultProviders);
            return mappedResult;
        }

        public IEnumerable<ProductDTO> GetProducts()
        {
            var resultProducts = _dataBase.Products.GetAll();
            return makeMap(resultProducts);
        }

        public IEnumerable<ProductDTO> GetProducts(ProviderDTO provider)
        {
            var resultProducts = _dataBase.Products.GetAll().Where(p => p.ProviderId == provider.Id);
            return makeMap(resultProducts);
        }

        public IEnumerable<ProductDTO> GetProducts(CategoryDTO category)
        {
            var resultProducts = _dataBase.Products.GetAll().Where(p => p.CategoryId == category.Id);
            return makeMap(resultProducts);
        }

        public IEnumerable<ProductDTO> GetProductsCheaper(int maxPrice)
        {
            var resultProducts = _dataBase.Products.GetAll().Where(p => p.Price < maxPrice);
            return makeMap(resultProducts);
        }

        public IEnumerable<ProductDTO> GetProductsExpensive(int minPrice)
        {
            var resultProducts = _dataBase.Products.GetAll().Where(p => p.Price > minPrice);
            return makeMap(resultProducts);
        }

        private IEnumerable<ProductDTO> makeMap(IEnumerable<Product> listToMap)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Product, ProductDTO>());
            return Mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(listToMap);
        }
    }
}
