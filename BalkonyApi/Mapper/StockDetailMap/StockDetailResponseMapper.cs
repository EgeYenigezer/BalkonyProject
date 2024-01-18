using AutoMapper;
using BalkonyEntity.DTO.StockDetail;
using BalkonyEntity.Poco;

namespace BalkonyApi.Mapper.StockDetailMap
{
    public class StockDetailResponseMapper:Profile
    {
        public StockDetailResponseMapper()
        {
            CreateMap<StockDetail, StockDetailDTOResponse>()
                .ForMember(dest => dest.ProductName, opt =>
                {
                    opt.MapFrom(src => src.Stock.Product.Name);
                }).
                ForMember(dest => dest.SupplierName, opt =>
                {
                    opt.MapFrom(src => src.Supplier.Name);
                }).ReverseMap();
        }
    }
}
