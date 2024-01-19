using AutoMapper;
using BalkonyEntity.DTO.ProductUnit;
using BalkonyEntity.Poco;

namespace BalkonyApi.Mapper.ProductUnitMap
{
    public class ProductUnitResponseMapper:Profile
    {
        public ProductUnitResponseMapper()
        {
            CreateMap<ProductUnit, ProductUnitDTOResponse>().ForMember(dest => dest.UnitName, opt =>
            {
                opt.MapFrom(src => src.Unit.UnitName);
            }).ReverseMap();
        }
    }
}
