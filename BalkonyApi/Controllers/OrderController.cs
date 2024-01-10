using AutoMapper;
using BalkonyBusiness.Abstract;
using BalkonyEntity.DTO.Order;
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

        [HttpPost("/AddOrder")]
        public async Task<IActionResult> AddOrder(OrderDTORequest orderDTORequest)
        {

            return Ok();
        }

        [HttpPost("/UpdateOrder")]
        public async Task<IActionResult> UpdateOrder(OrderDTORequest orderDTORequest)
        {

            return Ok();
        }

        
    }
}
