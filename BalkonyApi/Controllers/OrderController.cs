using AutoMapper;
using BalkonyBusiness.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace BalkonyApi.Controllers
{
    [ApiController]
    [Route("[Action]")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(IMapper mapper, IOrderService orderService)
        {
            _mapper = mapper;
            _orderService = orderService;
        }

        public async Task<IActionResult> AddOrder()
        {
            return Ok();
        }
    }
}
