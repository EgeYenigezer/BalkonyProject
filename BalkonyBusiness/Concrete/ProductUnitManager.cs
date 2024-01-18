using BalkonyBusiness.Abstract;
using BalkonyDAL.Abstract.DataManagement;
using BalkonyEntity.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BalkonyBusiness.Concrete
{
    public class ProductUnitManager : IProductUnitService
    {
        private readonly IUnitOfWork _uow;

        public ProductUnitManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<ProductUnit> AddAsync(ProductUnit Entity)
        {
            await _uow.ProductUnitRepository.AddAsync(Entity);
            await _uow.SaveChangeAsync();
            return Entity;
        }

        public async Task DeleteAsync(ProductUnit Entity)
        {
            await _uow.ProductUnitRepository.RemoveAsync(Entity);
            await _uow.SaveChangeAsync();
        }

        public async Task<IEnumerable<ProductUnit>> GetAllAsync(Expression<Func<ProductUnit, bool>> Filter = null, params string[] IncludeProperties)
        {
            return await _uow.ProductUnitRepository.GetAllAsync(Filter, IncludeProperties);
        }

        public async Task<ProductUnit> GetAsync(Expression<Func<ProductUnit, bool>> Filter, params string[] IncludeProperties)
        {
            return await _uow.ProductUnitRepository.GetAsync(Filter, IncludeProperties);
        }

        public async Task UpdateAsync(ProductUnit Entity)
        {
            await _uow.ProductUnitRepository.UpdateAsync(Entity);
            await _uow.SaveChangeAsync();
        }
    }
}
