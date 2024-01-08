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
    public class CustomerManager : ICustomerService
    {
        private readonly IUnitOfWork _uow;

        public CustomerManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Customer> AddAsync(Customer Entity)
        {
            await _uow.CustomerRepository.AddAsync(Entity);
            await _uow.SaveChangeAsync();
            return Entity;
        }

        public async Task DeleteAsync(Customer Entity)
        {
            await _uow.CustomerRepository.RemoveAsync(Entity);
            await _uow.SaveChangeAsync();
        }

        public async Task<IEnumerable<Customer>> GetAllAsync(Expression<Func<Customer, bool>> Filter = null, params string[] IncludeProperties)
        {
            return await _uow.CustomerRepository.GetAllAsync(Filter, IncludeProperties);
        }

        public async Task<Customer> GetAsync(Expression<Func<Customer, bool>> Filter, params string[] IncludeProperties)
        {
            return await _uow.CustomerRepository.GetAsync(Filter, IncludeProperties);
        }

        public async Task UpdateAsync(Customer Entity)
        {
            await _uow.CustomerRepository.UpdateAsync(Entity);
            await _uow.SaveChangeAsync();
        }
    }
}
