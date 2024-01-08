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
    public class SupplierManager : ISupplierService
    {
        private readonly IUnitOfWork _uow;

        public SupplierManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Supplier> AddAsync(Supplier Entity)
        {
            await _uow.SupplierRepository.AddAsync(Entity);
            await _uow.SaveChangeAsync();
            return Entity;
        }

        public async Task DeleteAsync(Supplier Entity)
        {
            await _uow.SupplierRepository.RemoveAsync(Entity);
            await _uow.SaveChangeAsync();
        }

        public async Task<IEnumerable<Supplier>> GetAllAsync(Expression<Func<Supplier, bool>> Filter = null, params string[] IncludeProperties)
        {
            return await _uow.SupplierRepository.GetAllAsync(Filter, IncludeProperties);
        }

        public async Task<Supplier> GetAsync(Expression<Func<Supplier, bool>> Filter, params string[] IncludeProperties)
        {
            return await _uow.SupplierRepository.GetAsync(Filter, IncludeProperties);
        }

        public async Task UpdateAsync(Supplier Entity)
        {
            await _uow.SupplierRepository.UpdateAsync(Entity);
            await _uow.SaveChangeAsync();
        }
    }
}
