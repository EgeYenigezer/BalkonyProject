using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalkonyBusiness.Cache
{
    public interface ICacheService
    {

        public T Get<T>(string key);
        public object Get(string key);
        public void Add(string key, Object value, int duration);
        public bool IsAdd(string key);
        public void Remove(string key);
        public void RemoveByPattern(string pattern);

    }
}
