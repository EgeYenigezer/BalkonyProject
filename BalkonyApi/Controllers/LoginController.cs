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

        [HttpGet("/Login")]
        public async Task<IActionResult> Login(LoginDTORequest loginDTORequest)
        {
            var user = await _userService.GetAsync(x=>x.Email==loginDTORequest.Email&x.Password==loginDTORequest.Password);

            if (user==null)
            {
                return NotFound(ApiResult<LoginDTORequest>.AuthenticationError);
            }

            return Ok();
        }
        
    }
}
