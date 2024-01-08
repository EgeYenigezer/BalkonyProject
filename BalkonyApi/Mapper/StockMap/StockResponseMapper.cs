using AutoMapper;
using BalkonyEntity.DTO.Stock;
using BalkonyEntity.Poco;

namespace BalkonyApi.Mapper.StockMap
{
    public class StockResponseMapper:Profile
    {
        public StockResponseMapper()
        {
            CreateMap<Stock, StockDTOResponse>();
            CreateMap<StockDTOResponse, Stock>();
        }
    }
}
