using AutoMapper;
using BalkonyEntity.DTO.Customer;
using BalkonyEntity.Poco;

namespace BalkonyApi.Mapper.CustomerMap
{
    public class CustomerResponseMapper:Profile
    {
        public CustomerResponseMapper()
        {
            CreateMap<Customer,CustomerDTOResponse>();
            CreateMap<CustomerDTOResponse, Customer>();
        }
    }
}
