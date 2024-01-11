using AutoMapper;
using BalkonyEntity.DTO.Stock;
using BalkonyEntity.Poco;

namespace BalkonyApi.Mapper.StockMap
{
    public class StockResponseMapper:Profile
    {
        public StockResponseMapper()
        {
            CreateMap<Stock, StockDTOResponse>().ForMember(dest => dest.StockName, opt =>
            {
                opt.MapFrom(src => src.Product.Name);
            }).ReverseMap();
           
        }
    }
}
