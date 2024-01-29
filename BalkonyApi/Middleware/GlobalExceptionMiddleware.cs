using BalkonyEntity.Result;
using BalkonyHelper.CustomException;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace BalkonyApi.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {

            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {

                if (e.GetType()==typeof(FieldValidationException))
                {
                    List<string> errors = new();
                       errors = e.Data["FieldValidationMessage"] as List<string>;

                    httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    httpContext.Response.ContentType = "application/json";
                    await httpContext.Response.WriteAsJsonAsync(ApiResult<FieldValidationException>.FieldValdationError(errors), new JsonSerializerOptions()
                    {
                        PropertyNamingPolicy = null
                    });


                }
                else if (e.GetType()==typeof(TokenValidationException))
                {
                    httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    httpContext.Response.ContentType = "application/json";
                    await httpContext.Response.WriteAsJsonAsync(ApiResult<TokenValidationException>.TokenNotFound(),new JsonSerializerOptions()
                    { 
                        PropertyNamingPolicy=null
                    
                    
                    });
                }
                else if (e.GetType()==typeof(SecurityTokenSignatureKeyNotFoundException))
                {
                    httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    httpContext.Response.ContentType = "application/json";
                    await httpContext.Response.WriteAsJsonAsync(ApiResult<TokenValidationException>.TokenValidationError(), new
                        JsonSerializerOptions()
                    { 
                        PropertyNamingPolicy = null 
                    });

                }
                else if (e.GetType()==typeof(TokenNotFoundException))
                {
                    var message = e.Data["TokenNotFoundMessage"];
                    httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    httpContext.Response.ContentType = "application/json";
                    await httpContext.Response.WriteAsJsonAsync(ApiResult<TokenNotFoundException>.TokenNotFound(),new JsonSerializerOptions()
                    {
                        PropertyNamingPolicy = null
                    });
                }
                else if (e.GetType() == typeof(TokenException))
                {
                    httpContext.Response.StatusCode= (int)HttpStatusCode.Unauthorized;
                    httpContext.Response.ContentType = "application/json";
                    await httpContext.Response.WriteAsJsonAsync(ApiResult<TokenException>.TokenValidationError(), new JsonSerializerOptions()
                    {
                        PropertyNamingPolicy = null
                    });
                }
                else
                {
                    httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    httpContext.Response.ContentType = "application/json";
                    await httpContext.Response.WriteAsJsonAsync(ApiResult<Exception>.Error(), new JsonSerializerOptions()
                    {
                        PropertyNamingPolicy = null
                    });
                }
            }


            
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class GlobalExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseGlobalExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GlobalExceptionMiddleware>();
        }
    }
}
