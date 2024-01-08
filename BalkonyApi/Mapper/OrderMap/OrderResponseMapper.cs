using AutoMapper;
using BalkonyEntity.DTO.Order;
using BalkonyEntity.Poco;

namespace BalkonyApi.Mapper.OrderMap
{
    public class OrderResponseMapper:Profile
    {
        public OrderResponseMapper()
        {
            CreateMap<Order,OrderDTOResponse>();
            CreateMap<OrderDTOResponse, Order>();
        }
    }
}
