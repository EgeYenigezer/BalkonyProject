using AutoMapper;
using BalkonyEntity.DTO.Unit;
using BalkonyEntity.Poco;

namespace BalkonyApi.Mapper.UnitMap
{
    public class UnitResponseMapper:Profile
    {
        public UnitResponseMapper()
        {
            CreateMap<Unit, UnitDTOResponse>();
            CreateMap<UnitDTOResponse, Unit>();
        }
    }
}
