using BalkonyBusiness.Abstract;
using BalkonyEntity.Poco;
using Microsoft.AspNetCore.Mvc;

namespace BalkonyApi.Controllers
{
    [ApiController]
    [Route("[Action]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> AddProduct(Product product)
        {
            return Ok(product);
        }
    }
}
