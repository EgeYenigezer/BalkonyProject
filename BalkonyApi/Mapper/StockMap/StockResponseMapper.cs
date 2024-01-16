using AutoMapper;
using BalkonyEntity.DTO.Stock;
using BalkonyEntity.Poco;

namespace BalkonyApi.Mapper.StockMap
{
    public class StockResponseMapper:Profile
    {
        public StockResponseMapper()
        {
            CreateMap<Stock, StockDTOResponse>().ForMember(dest => dest.ProductName, opt =>
            {
                opt.MapFrom(src => src.Product.Name);
            }).ForMember(dest => dest.StockTitle, opt =>
            {
                opt.MapFrom(src => src.Product.Name);
            }).ReverseMap();
           
        }
    }
}
