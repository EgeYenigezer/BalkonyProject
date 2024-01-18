using AutoMapper;
using BalkonyEntity.DTO.ProductUnit;
using BalkonyEntity.Poco;

namespace BalkonyApi.Mapper.ProductUnitMap
{
    public class ProductUnitRequestMapper:Profile
    {
        public ProductUnitRequestMapper()
        {
            CreateMap<ProductUnit,ProductUnitDTORequest>();
            CreateMap<ProductUnitDTORequest, ProductUnit>();
        }
    }
}
