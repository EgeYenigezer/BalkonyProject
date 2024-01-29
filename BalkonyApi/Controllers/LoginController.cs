using BalkonyApi.Aspects;
using BalkonyApi.Validation.FluentValidation;
using BalkonyBusiness.Abstract;
using BalkonyEntity.DTO.Login;
using BalkonyEntity.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BalkonyApi.Controllers
{
    [ApiController]
    [Route("[Action]")]
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public LoginController(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }

        [ValidationFilter(typeof(LoginValidator))]
        [HttpPost("/Login")]
        public async Task<IActionResult> Login(LoginDTORequest loginDTORequest)
        {
            var user = await _userService.GetAsync(x=>x.Email==loginDTORequest.Email&x.Password==loginDTORequest.Password);

            if (user==null)
            {
                
                return NotFound(ApiResult<LoginDTORequest>.AuthenticationError("Kullanıcı Adı veya Şifre yanlış!!"));
            }
            else
            {
                var key = Encoding.UTF8.GetBytes(_configuration.GetValue<string>("AppSettings:JWTKey"));

                var claims = new List<Claim>();
                claims.Add(new Claim("UserName", user.Name));
                claims.Add(new Claim("Password", user.Password));

                var jwt = new JwtSecurityToken(
                    
                    expires:DateTime.Now.AddMinutes(1),
                    claims:claims,
                    issuer:"http://egeyenigezer.com",
                    signingCredentials:new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature));
                var token = new JwtSecurityTokenHandler().WriteToken(jwt);

                LoginDTOResponse loginDTOResponse = new();

                loginDTOResponse.Id = user.Id;
                loginDTOResponse.Name=user.Name;
                loginDTOResponse.Token = token;

                return Ok(ApiResult<LoginDTOResponse>.SuccesWithData(loginDTOResponse));
            }

            
        }
        
    }
}
