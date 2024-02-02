using BalkonyHelper.CustomException;
using BalkonyHelper.Globals;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;

namespace BalkonyApi.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ApiAuthorizationMiddlerware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        private readonly IOptionsMonitor<JWTExceptURLList> _optionsMonitor;

        public ApiAuthorizationMiddlerware(RequestDelegate next, IConfiguration configuration, IOptionsMonitor<JWTExceptURLList> optionsMonitor)
        {
            _next = next;
            _configuration = configuration;
            _optionsMonitor = optionsMonitor;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (!_optionsMonitor.CurrentValue.URLList.Contains(httpContext.Request.Path))
            {
                var jwtHandler = new JwtSecurityTokenHandler();
                string requestheader = httpContext.Request.Headers["Authorization"];


                if (requestheader!=null)
                {
                    var token = requestheader.Replace("Bearer ", "");
                    var key = Encoding.UTF8.GetBytes(_configuration.GetValue<string>("AppSettings:JWTKey"));

                    jwtHandler.ValidateToken(token, new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    },out SecurityToken validatedToken);

                    var jwtToken = (JwtSecurityToken)validatedToken;

                    if (jwtToken.ValidTo<DateTime.UtcNow)
                    {
                        throw new TokenException();
                    }


                }
                else
                {
                    throw new TokenNotFoundException("Token Bilgisi Gelmedi!!");
                }

            }

            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ApiAuthorizationMiddlerwareExtensions
    {
        public static IApplicationBuilder UseApiAuthorizationMiddlerware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ApiAuthorizationMiddlerware>();
        }
    }
}
