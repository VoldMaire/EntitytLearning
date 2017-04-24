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
    public class ProviderService : IProviderService
    {
        private IUnitOfWork _dataBase;

        public ProviderService()
        {
            _dataBase = new UnitOfWork();
        }

        public void Dispose()
        {
            _dataBase.Dispose();
        }

        public IEnumerable<ProviderDTO> GetProviders(CategoryDTO category)
        {
            if (category == null)
                throw new ArgumentNullException("Argument cannot be null.");
            var products = _dataBase.Products.GetAll().Where(p => p.CategoryId == category.Id);
            var resultProviders = from prov in _dataBase.Providers.GetAll()
                         from prod in products
                         where prod.ProviderId == prov.Id
                         select prov;
            
            Mapper.Initialize(cfg => cfg.CreateMap<Provider, ProviderDTO>());
            IEnumerable<ProviderDTO> mappedResult = Mapper.Map<IEnumerable<Provider>, IEnumerable<ProviderDTO>>(resultProviders);
            return mappedResult;
        }

        public IEnumerable<ProviderDTO> GetProvidersByCity(string city)
        {
            var resultProviders = _dataBase.Providers.GetAll().Where(p => p.City == city);
            Mapper.Initialize(cfg => cfg.CreateMap<Provider, ProviderDTO>());
            IEnumerable<ProviderDTO> mappedResult = Mapper.Map<IEnumerable<Provider>, IEnumerable<ProviderDTO>>(resultProviders);
            return mappedResult;
        }
    }
}
