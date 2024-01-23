using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;

namespace BalkonyApi.Aspects
{
    public class GetOrCreateCache : Attribute, IActionFilter
    {
        private readonly IMemoryCache _cache;

        public GetOrCreateCache(IMemoryCache cache)
        {
            _cache = cache;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _cache.CreateEntry(context.ActionDescriptor);
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
