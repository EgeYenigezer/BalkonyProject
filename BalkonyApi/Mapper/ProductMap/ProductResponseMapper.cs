using AutoMapper;
using BalkonyEntity.DTO.Product;
using BalkonyEntity.Poco;

namespace BalkonyApi.Mapper.ProductMap
{
    public class ProductResponseMapper:Profile
    {
        public ProductResponseMapper()
        {
            CreateMap<Product,ProductDTOResponse>();
            CreateMap<ProductDTOResponse, Product>();
        }
    }
}
