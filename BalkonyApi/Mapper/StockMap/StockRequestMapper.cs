using AutoMapper;
using BalkonyEntity.DTO.Stock;
using BalkonyEntity.Poco;

namespace BalkonyApi.Mapper.StockMap
{
    public class StockRequestMapper:Profile
    {
        public StockRequestMapper()
        {
            CreateMap<Stock, StockDTORequest>();
            CreateMap<StockDTORequest, Stock>();
        }
    }
}
