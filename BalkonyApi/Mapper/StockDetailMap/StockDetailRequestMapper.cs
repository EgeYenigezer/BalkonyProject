using AutoMapper;
using BalkonyEntity.DTO.StockDetail;
using BalkonyEntity.Poco;

namespace BalkonyApi.Mapper.StockDetailMap
{
    public class StockDetailRequestMapper:Profile
    {
        public StockDetailRequestMapper()
        {
            CreateMap<StockDetail,StockDetailDTORequest>();
            CreateMap<StockDetailDTORequest, StockDetail>();
        }
    }
}
