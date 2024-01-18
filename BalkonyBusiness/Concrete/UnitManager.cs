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
    public class UnitManager : IUnitService
    {
        private readonly IUnitOfWork _uow;

        public UnitManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Unit> AddAsync(Unit Entity)
        {
            await _uow.UnitRepository.AddAsync(Entity);
            await _uow.SaveChangeAsync();
            return Entity;
        }

        public async Task DeleteAsync(Unit Entity)
        {
            await _uow.UnitRepository.RemoveAsync(Entity);
            await _uow.SaveChangeAsync();
        }

        public async Task<IEnumerable<Unit>> GetAllAsync(Expression<Func<Unit, bool>> Filter = null, params string[] IncludeProperties)
        {
            return await _uow.UnitRepository.GetAllAsync(Filter, IncludeProperties);
        }

        public async Task<Unit> GetAsync(Expression<Func<Unit, bool>> Filter, params string[] IncludeProperties)
        {
            return await _uow.UnitRepository.GetAsync(Filter, IncludeProperties);
        }

        public async Task UpdateAsync(Unit Entity)
        {
            await _uow.UnitRepository.UpdateAsync(Entity);
            await _uow.SaveChangeAsync();
        }
    }
}
