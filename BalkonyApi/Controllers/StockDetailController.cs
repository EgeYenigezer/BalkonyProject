using Microsoft.AspNetCore.Mvc;

namespace BalkonyApi.Controllers
{
    [ApiController]
    [Route("[Action]")]
    public class StockDetailController : Controller
    {
        [HttpPost("/AddStockDetail")]
        public async Task<IActionResult> AddStockDetail()
        {
            return Ok();
        }
        
    }
}
