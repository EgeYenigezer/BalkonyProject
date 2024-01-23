using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalkonyBusiness.Abstract.Utilities
{
    public interface ICacheService
    {
        T Get<T>(string key);
        Object Get(string key);
    }
}
