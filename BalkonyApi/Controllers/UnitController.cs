using AutoMapper;
using BalkonyBusiness.Abstract;
using BalkonyEntity.DTO.Unit;
using BalkonyEntity.Poco;
using BalkonyEntity.Result;
using Microsoft.AspNetCore.Mvc;

namespace BalkonyApi.Controllers
{
    [ApiController]
    [Route("[Action]")]
    public class UnitController : Controller
    {
        private readonly IUnitService _unitService;
        private readonly IMapper _mapper;

        public UnitController(IUnitService unitService, IMapper mapper)
        {
            _unitService = unitService;
            _mapper = mapper;
        }

        [HttpPost("/AddUnit")]
        public async Task<IActionResult> AddUnit(UnitDTORequest unitDTORequest)
        {
            var unit = _mapper.Map<Unit>(unitDTORequest);
            await _unitService.AddAsync(unit);

            UnitDTOResponse unitDTOResponse = _mapper.Map<UnitDTOResponse>(unit);
            return Ok(ApiResult<UnitDTOResponse>.SuccesWithData(unitDTOResponse));
        }

        [HttpPost("/UpdateUnit")]
        public async Task<IActionResult> UpdateUnit(UnitDTORequest unitDTOReqeust)
        {
            var unit = await _unitService.GetAsync(x => x.Id == unitDTOReqeust.Id);

            unit = _mapper.Map(unitDTOReqeust, unit);

            return Ok(ApiResult<UnitDTOResponse>.SuccesWithOutData());
        }

        [HttpDelete("/DeleteUnit/{unitId}")]
        public async Task<IActionResult> DeleteUnit(Int64 unitId)
        {
            var unit = await _unitService.GetAsync(x=>x.Id==unitId);

            await _unitService.DeleteAsync(unit);

            return Ok(ApiResult<UnitDTOResponse>.SuccesWithOutData());
        }

        [HttpGet("/Units")]
        public async Task<IActionResult> GetAllUnit()
        {
            var units= await _unitService.GetAllAsync();

            List<UnitDTOResponse> unitDTOResponses = new();

            foreach (var unit in units)
            {
                unitDTOResponses.Add(_mapper.Map<UnitDTOResponse>(unit));
            }

            return Ok(ApiResult<List<UnitDTOResponse>>.SuccesWithData(unitDTOResponses));
        }

        [HttpGet("/GetUnit/{unitId}")]
        public async Task<IActionResult> GetUnit(Int64 unitId)
        {
            var unit = await _unitService.GetAsync(x=>x.Id==unitId);

            UnitDTOResponse unitDTOResponse = _mapper.Map<UnitDTOResponse>(unit);

            return Ok(ApiResult<UnitDTOResponse>.SuccesWithData(unitDTOResponse));
        }
    }
}
