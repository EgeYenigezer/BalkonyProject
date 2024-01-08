using AutoMapper;
using BalkonyEntity.DTO.Order;
using BalkonyEntity.Poco;

namespace BalkonyApi.Mapper.OrderMap
{
    public class OrderRequestMapper:Profile
    {
        public OrderRequestMapper()
        {
            CreateMap<Order, OrderDTORequest>();
            CreateMap<OrderDTORequest, Order>();
        }
    }
}
