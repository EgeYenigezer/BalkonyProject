using AutoMapper;
using BalkonyEntity.DTO.Unit;
using BalkonyEntity.Poco;

namespace BalkonyApi.Mapper.UnitMap
{
    public class UnitRequestMapper:Profile
    {
        public UnitRequestMapper()
        {
            CreateMap<Unit,UnitDTORequest>();
            CreateMap<UnitDTORequest, Unit>();
        }
    }
}
