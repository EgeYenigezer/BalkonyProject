using AutoMapper;
using BalkonyEntity.DTO.Product;
using BalkonyEntity.Poco;

namespace BalkonyApi.Mapper.ProductMap
{
    public class ProductRequestMapper:Profile
    {
        public ProductRequestMapper()
        {
            CreateMap<Product,ProductDTORequest>();
            CreateMap<ProductDTORequest, Product>();
        }
    }
}
