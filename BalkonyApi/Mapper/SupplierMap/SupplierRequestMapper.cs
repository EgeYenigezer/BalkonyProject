using AutoMapper;
using BalkonyEntity.DTO.Supplier;
using BalkonyEntity.Poco;

namespace BalkonyApi.Mapper.SupplierMap
{
    public class SupplierRequestMapper:Profile
    {
        public SupplierRequestMapper()
        {
            CreateMap<Supplier, SupplierDTORequest>();
            CreateMap<SupplierDTORequest, Supplier>();
        }
    }
}
