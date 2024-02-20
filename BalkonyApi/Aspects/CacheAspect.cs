using BalkonyBusiness.Cache;
using BalkonyEntity.Result;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace BalkonyApi.Aspects
{
    public class CacheAspect:ActionFilterAttribute
    {
        private readonly int _duration;
        private ICacheService _cacheService;

        public CacheAspect(int duration)
        {

            _duration = duration;
            
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            _cacheService=(ICacheService)context.HttpContext.RequestServices.GetService<ICacheService>();
            var actionDescriptor = context.ActionDescriptor.DisplayName;
            
            string methodName =actionDescriptor.Remove(0, 23);
            string key = methodName.Replace(" (BalkonyApi)","");


            if (_cacheService.IsAdd(key))
            {
                context.Result = new ObjectResult(_cacheService.Get(key)); 
                
            }
            
            
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
            _cacheService = (ICacheService)context.HttpContext.RequestServices.GetService<ICacheService>();
            var actionDescriptor = context.ActionDescriptor.DisplayName;
            
            string methodName = actionDescriptor.Remove(0, 23);
            string key = methodName.Replace(" (BalkonyApi)", "");

            if (context.Result is ObjectResult objectResult)
            {

                var cacheData = objectResult;

                if (!(_cacheService.IsAdd(key)))
                {
                    _cacheService.Add(key, cacheData.Value, _duration);
                }
            }

            

        }

    }
}
