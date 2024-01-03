using BalkonyDAL.Abstract.DataManagement;
using BalkonyEntity.Poco.Base;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BalkonyDAL.Concrete.EntityFramework.DataManagement
{
    public class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        public Task<EntityEntry<T>> AddAsync(T Entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> Filter = null, params string[] IncludeProperties)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync(Expression<Func<T, bool>> Filter, params string[] IncludeProperties)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(T Entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T Entity)
        {
            throw new NotImplementedException();
        }
    }
}
