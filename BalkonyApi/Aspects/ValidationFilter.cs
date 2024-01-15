using BalkonyApi.Validation.FluentValidation;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BalkonyApi.Aspects
{
    public class ValidationFilter : Attribute, IAsyncActionFilter
    {
        private readonly Type _validatorType;

        public ValidationFilter(Type validatorType)
        {
            _validatorType = validatorType;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            ValidationHelper.Validate(_validatorType, context.ActionArguments.Values.ToArray());
            var executedContext = await next();
        }
    }
}
