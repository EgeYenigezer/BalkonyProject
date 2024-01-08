using AutoMapper;
using BalkonyEntity.DTO.Supplier;
using BalkonyEntity.Poco;

namespace BalkonyApi.Mapper.SupplierMap
{
    public class SupplierResponseMapper:Profile
    {
        public SupplierResponseMapper()
        {
            CreateMap<Supplier,SupplierDTOResponse>();
            CreateMap<SupplierDTOResponse, Supplier>();
        }
    }
}
