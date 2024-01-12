using AutoMapper;
using BalkonyBusiness.Abstract;
using BalkonyEntity.DTO.StockDetail;
using BalkonyEntity.Poco;
using BalkonyEntity.Result;
using Microsoft.AspNetCore.Mvc;

namespace BalkonyApi.Controllers
{
    [ApiController]
    [Route("[Action]")]
    public class StockDetailController : Controller
    {
        private readonly IStockDetailService _stockDetailService;
        private readonly IMapper _mapper;

        public StockDetailController(IMapper mapper, IStockDetailService stockDetailService)
        {
            _mapper = mapper;
            _stockDetailService = stockDetailService;
        }

        [HttpPost("/AddStockDetail")]
        public async Task<IActionResult> AddStockDetail(StockDetailDTORequest stockDetailDTORequest)
        {
            var stockDetail = _mapper.Map<StockDetail>(stockDetailDTORequest);
            await _stockDetailService.AddAsync(stockDetail);
            StockDetailDTOResponse stockDetailDTOResponse = new();
            stockDetailDTOResponse = _mapper.Map<StockDetailDTOResponse>(stockDetailDTOResponse);
            return Ok(ApiResult<StockDetailDTOResponse>.SuccesWithData(stockDetailDTOResponse));
        }

        [HttpPost("/UpdateStockDetail")]
        public async Task<IActionResult> UpdateStockDetail(StockDetailDTORequest stockDetailDTORequest)
        {
            var stockDetail = await _stockDetailService.GetAsync(stockdetail=>stockdetail.Id==stockDetailDTORequest.Id);
            
            await _stockDetailService.UpdateAsync(stockDetail);

            StockDetailDTOResponse stockDetailDTOResponse = _mapper.Map<StockDetailDTOResponse>(stockDetail);

            return Ok(ApiResult<StockDetailDTOResponse>.SuccesWithOutData());
        }

        [HttpDelete("/DeleteStockDetail/{stockDetailId}")]
        public async Task<IActionResult> DeleteStockDetail(long stockDetailId)
        {
            var stockDetail = await _stockDetailService.GetAsync(x => x.Id == stockDetailId);

            await _stockDetailService.DeleteAsync(stockDetail);

            return Ok(ApiResult<StockDetailDTOResponse>.SuccesWithOutData());
        }

        [HttpGet("/StockDetails/{stockId}")]
        public async Task<IActionResult> GetAllStockDetail(long stockId)
        {
            var stockDetails = await _stockDetailService.GetAllAsync(x=>x.StockId==stockId,"Supplier","Product");

            List<StockDetailDTOResponse> stockDetailDTOResponses = new();

            foreach (var stockDetail in stockDetails)
            {
                stockDetailDTOResponses.Add(_mapper.Map<StockDetailDTOResponse>(stockDetail));
            }

            return Ok(ApiResult<List<StockDetailDTOResponse>>.SuccesWithData(stockDetailDTOResponses));
        }

        [HttpGet("/GetStockDetail/{stockDetailId}")]
        public async Task<IActionResult> GetStockDetail(long stockDetailId)
        {
            var stockDetail = await _stockDetailService.GetAsync(x=>x.Id==stockDetailId,"Supplier","Product");

            StockDetailDTOResponse stockDetailDTOResponse = _mapper.Map<StockDetailDTOResponse>(stockDetail);
            return Ok(ApiResult<StockDetailDTOResponse>.SuccesWithData(stockDetailDTOResponse));
        }
    }
}
