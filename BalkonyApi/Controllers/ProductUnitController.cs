using AutoMapper;
using BalkonyBusiness.Abstract;
using BalkonyEntity.DTO.ProductUnit;
using BalkonyEntity.Poco;
using BalkonyEntity.Result;
using Microsoft.AspNetCore.Mvc;

namespace BalkonyApi.Controllers
{
    [ApiController]
    [Route("[Action]")]
    public class ProductUnitController : Controller
    {
        private readonly IProductUnitService _productUnitService;
        private readonly IMapper _mapper;

        public ProductUnitController(IMapper mapper, IProductUnitService productUnitService)
        {
            _mapper = mapper;
            _productUnitService = productUnitService;
        }

        [HttpPost("/AddProductUnit")]
        public async Task<IActionResult> AddProductUnit(ProductUnitDTORequest productUnitDTORequest)
        {
            var productUnit = _mapper.Map<ProductUnit>(productUnitDTORequest);

            await _productUnitService.AddAsync(productUnit);

            ProductUnitDTOResponse productUnitDTOResponse = _mapper.Map<ProductUnitDTOResponse>(productUnit);
            return Ok(ApiResult<ProductUnitDTOResponse>.SuccesWithData(productUnitDTOResponse));
        }

        [HttpPost("/UpdateProductUnit")]
        public async Task<IActionResult> UpdateProductUnit(ProductUnitDTORequest productUnitDTORequest)
        {
            var productUnit = await _productUnitService.GetAsync(x=>x.ProductId==productUnitDTORequest.ProductId&&x.UnitId==productUnitDTORequest.UnitId);

            productUnit = _mapper.Map(productUnitDTORequest, productUnit);

            await _productUnitService.UpdateAsync(productUnit);

            return Ok(ApiResult<ProductUnitDTOResponse>.SuccesWithOutData());
        }

        [HttpDelete("/DeleteProductUnit/{productUnitId}")]
        public async Task<IActionResult> DeleteProductUnit(Int64 productId,Int64 unitId)
        {
            var productUnit = await _productUnitService.GetAsync(x=>x.ProductId == productId&&x.UnitId== unitId);

            await _productUnitService.DeleteAsync(productUnit);

            return Ok(ApiResult<ProductUnitDTOResponse>.SuccesWithOutData());
        }

        [HttpGet("/ProductUnits/{productId}")]
        public async Task<IActionResult> GetAllProductOfUnit(Int64 productId)
        {
            var productUnits = await _productUnitService.GetAllAsync(x=>x.ProductId== productId, "Unit","Product");

            List<ProductUnitDTOResponse> productUnitDTOResponses = new();

            foreach (var productUnit in productUnits)
            {
                productUnitDTOResponses.Add(_mapper.Map<ProductUnitDTOResponse>(productUnit));
            }

            return Ok(ApiResult<List<ProductUnitDTOResponse>>.SuccesWithData(productUnitDTOResponses));
        }

        [HttpGet("/GetProductUnit/{productUnitId}")]
        public async Task<IActionResult> GetProductUnit(Int64 productUnitId) 
        {
            var productUnit = await _productUnitService.GetAsync(x=>x.Id==productUnitId);

            ProductUnitDTOResponse productUnitDTOResponse = _mapper.Map<ProductUnitDTOResponse>(productUnit);
            return Ok(ApiResult<ProductUnitDTOResponse>.SuccesWithData(productUnitDTOResponse));
        }
    }
}
