using Microsoft.AspNetCore.Mvc;

namespace BalkonyApi.Controllers
{
    [ApiController]
    [Route("[Action]")]
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
