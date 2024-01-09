using AutoMapper;
using BalkonyBusiness.Abstract;
using BalkonyEntity.DTO.User;
using BalkonyEntity.Poco;
using BalkonyEntity.Result;
using Microsoft.AspNetCore.Mvc;

namespace BalkonyApi.Controllers
{
    [ApiController]
    [Route("[Action]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }


        [HttpPost("/AddUser")]
        public async Task<IActionResult> AddUser(UserDTORequest userDTORequest)
        {
            User user = _mapper.Map<User>(userDTORequest);

            await _userService.AddAsync(user);

            UserDTOResponse userDTOResponse = _mapper.Map<UserDTOResponse>(user);

            return Ok(ApiResult<UserDTOResponse>.SuccesWithData(userDTOResponse));
        }

        [HttpPost("/UpdateUser")]
        public async Task<IActionResult> UpdateUser(UserDTORequest userDTORequest)
        {
            User user =_mapper.Map<User>(userDTORequest);

            await _userService.UpdateAsync(user);

            return Ok(ApiResult<UserDTOResponse>.SuccesWithOutData());
        }


        [HttpDelete("/DeleteUser")]
        public async Task<IActionResult> DeleteUser(Int64 userId)
        {
            User user = await _userService.GetAsync(x=>x.Id==userId);

            await _userService.DeleteAsync(user);

            return Ok(ApiResult<UserDTOResponse>.SuccesWithOutData());
        }



        [HttpGet("/Users")]
        public async Task<IActionResult> Users()
        {
            var Users = await _userService.GetAllAsync();

            
            List<UserDTOResponse> userDTOResponses = new List<UserDTOResponse>();

            foreach (var user in Users)
            {

                userDTOResponses.Add(_mapper.Map<UserDTOResponse>(user));

            }

            return Ok(ApiResult<List<UserDTOResponse>>.SuccesWithData(userDTOResponses));
        }

        [HttpGet("/GetUser/{id}")]
        public async Task<IActionResult> GetUser(Int64 userId)
        {
            User user = await _userService.GetAsync(x => x.Id==userId);

            UserDTOResponse userDTOResponse = _mapper.Map<UserDTOResponse>(user);
            

            return Ok(ApiResult<UserDTOResponse>.SuccesWithData(userDTOResponse));
        }

    }
}
