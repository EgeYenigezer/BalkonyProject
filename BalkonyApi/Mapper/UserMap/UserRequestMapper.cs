using AutoMapper;
using BalkonyEntity.DTO.User;
using BalkonyEntity.Poco;

namespace BalkonyApi.Mapper.UserMap
{
    public class UserRequestMapper:Profile
    {
        public UserRequestMapper()
        {
            CreateMap<User,UserDTORequest>();
            CreateMap<UserDTORequest, User>();
        }
    }
}
