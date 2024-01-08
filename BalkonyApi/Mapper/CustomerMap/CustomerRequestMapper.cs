using AutoMapper;
using BalkonyEntity.DTO.Customer;
using BalkonyEntity.Poco;

namespace BalkonyApi.Mapper.CustomerMap
{
    public class CustomerRequestMapper:Profile
    {

        public CustomerRequestMapper()
        {
            CreateMap<Customer,CustomerDTORequest>();
            CreateMap<CustomerDTORequest, Customer>();
        }
    }
}
