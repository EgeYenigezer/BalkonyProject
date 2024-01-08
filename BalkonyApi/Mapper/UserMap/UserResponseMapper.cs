using AutoMapper;
using BalkonyEntity.DTO.User;
using BalkonyEntity.Poco;

namespace BalkonyApi.Mapper.UserMap
{
    public class UserResponseMapper:Profile
    {
        public UserResponseMapper()
        {
            CreateMap<User, UserDTOResponse>();
            CreateMap<UserDTOResponse, User>();
        }
    }
}
