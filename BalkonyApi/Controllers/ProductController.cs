using AutoMapper;
using BalkonyBusiness.Abstract;
using BalkonyEntity.DTO.Product;
using BalkonyEntity.Poco;
using BalkonyEntity.Result;
using Microsoft.AspNetCore.Mvc;


namespace BalkonyApi.Controllers
{
    [ApiController]
    [Route("[Action]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpPost("/AddProduct")]
        public async Task<IActionResult> AddProduct(ProductDTORequest productDTORequest)
        {
            Product product = _mapper.Map<Product>(productDTORequest);

            await _productService.AddAsync(product);

            ProductDTOResponse productDTOResponse = _mapper.Map<ProductDTOResponse>(product);

            return Ok(ApiResult<ProductDTOResponse>.SuccesWithData(productDTOResponse));
        }

        [HttpPost("/UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(ProductDTORequest productDTORequest)
        {
            var product = await _productService.GetAsync(x => x.Id == productDTORequest.Id);

            product = _mapper.Map(productDTORequest, product);

            await _productService.UpdateAsync(product);

            return Ok(ApiResult<ProductDTOResponse>.SuccesWithOutData());
        }

        [HttpDelete("/DeleteProduct/{productId}")]
        public async Task<IActionResult> DeleteProduct(long productId)
        {
            var product = await _productService.GetAsync(x => x.Id == productId);

            await _productService.DeleteAsync(product);

            return Ok(ApiResult<ProductDTOResponse>.SuccesWithOutData());
        }



        [HttpGet("/Products")]
        public async Task<IActionResult> Products()
        {
            var Products = await _productService.GetAllAsync();


            List<ProductDTOResponse> productDTOResponses = new();
            foreach (var product in Products)
            {
                productDTOResponses.Add(_mapper.Map<ProductDTOResponse>(product));
            }

            return Ok(ApiResult<List<ProductDTOResponse>>.SuccesWithData(productDTOResponses));


        }

        [HttpGet("/GetProduct/{productId}")]
        public async Task<IActionResult> GetProduct(long productId)
        {

            ProductDTOResponse productDTOResponse = _mapper.Map<ProductDTOResponse>(await _productService.GetAsync(x => x.Id == productId));""


            return Ok(ApiResult<ProductDTOResponse>.SuccesWithData(productDTOResponse));
        }
    }
}
