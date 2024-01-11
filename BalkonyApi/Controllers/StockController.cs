using AutoMapper;
using BalkonyBusiness.Abstract;
using BalkonyEntity.DTO.Stock;
using BalkonyEntity.DTO.StockDetail;
using BalkonyEntity.Poco;
using BalkonyEntity.Result;
using Microsoft.AspNetCore.Mvc;

namespace BalkonyApi.Controllers
{
    [ApiController]
    [Route("[Action]")]
    public class StockController : Controller
    {
        private readonly IStockService _stockService;
        private readonly IMapper _mapper;

        public StockController(IMapper mapper, IStockService stockService)
        {
            _mapper = mapper;
            _stockService = stockService;
        }

        [HttpPost("/AddStock")]
        public async Task<IActionResult> AddStock(StockDTORequest stockDTORequest)
        {
            Stock stock = _mapper.Map<Stock>(stockDTORequest);
            await _stockService.AddAsync(stock);
            StockDTOResponse stockDTOResponse = new();
            stockDTOResponse = _mapper.Map<StockDTOResponse>(stock);
            return Ok(ApiResult<StockDTOResponse>.SuccesWithData(stockDTOResponse));
        }

        [HttpPost("/UpdateStock")]
        public async Task<IActionResult> UpdateStock(StockDTORequest stockDTORequest)
        {
            Stock stock = await _stockService.GetAsync(x => x.Id == stockDTORequest.Id);
            stock = _mapper.Map(stockDTORequest, stock);
            await _stockService.UpdateAsync(stock);
            return Ok(ApiResult<StockDTOResponse>.SuccesWithOutData());
        }

        [HttpDelete("/DeleteStock/{stockId}")]
        public async Task<IActionResult> DeleteStock(long stockId)
        {
            var stock  = await _stockService.GetAsync(x=>x.Id == stockId);
            await _stockService.DeleteAsync(stock);
            return Ok(ApiResult<StockDTOResponse>.SuccesWithOutData());
        }

        [HttpGet("/Stocks/{userId}")]
        public async Task<IActionResult> GetAllStock(long userId)
        {
            var stocks = await _stockService.GetAllAsync(x=>x.UserId==userId);
            List<StockDTOResponse> stockDTOResponses = new();
            foreach (var stock in stocks)
            {
                stockDTOResponses.Add(_mapper.Map<StockDTOResponse>(stock));
            }
            return Ok(ApiResult<List<StockDTOResponse>>.SuccesWithData(stockDTOResponses));
        }

        [HttpGet("/GetStock/{stockId}")]
        public async Task<IActionResult> GetStock(long stockId)
        {
            var stock = await _stockService.GetAsync(x=>x.Id == stockId);
            StockDTOResponse stockDTOResponse = _mapper.Map<StockDTOResponse>(stock);
            return Ok(ApiResult<StockDTOResponse>.SuccesWithData(stockDTOResponse));
        }
    }
}
