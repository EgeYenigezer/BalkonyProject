using AutoMapper;
using BalkonyEntity.DTO.StockDetail;
using BalkonyEntity.Poco;

namespace BalkonyApi.Mapper.StockDetailMap
{
    public class StockDetailResponseMapper:Profile
    {
        public StockDetailResponseMapper()
        {
            CreateMap<StockDetail,StockDetailDTOResponse>();
            CreateMap<StockDetailDTOResponse, StockDetail>();
        }
    }
}
