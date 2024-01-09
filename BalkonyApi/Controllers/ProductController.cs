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
    }
}
