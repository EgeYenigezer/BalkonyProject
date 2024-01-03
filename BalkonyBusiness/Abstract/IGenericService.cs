using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BalkonyBusiness.Abstract
{
    public interface IGenericService<T>
    {
        Task<T> AddAsync(T Entity);
        Task DeleteAsync(T Entity);
        Task UpdateAsync(T Entity);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T,bool>> Filter=null,params string[] IncludeProperties);
        Task<T> GetAsync(Expression<Func<T,bool>> Filter,params string[] IncludeProperties);

    }
}
