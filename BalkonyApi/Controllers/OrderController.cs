using AutoMapper;
using BalkonyBusiness.Abstract;
using BalkonyEntity.DTO.Order;
using BalkonyEntity.Poco;
using BalkonyEntity.Result;
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
            Order order = _mapper.Map<Order>(orderDTORequest);
            await _orderService.AddAsync(order);

            OrderDTOResponse orderDTOResponse = new();
            orderDTOResponse = _mapper.Map<OrderDTOResponse>(order);
            return Ok(ApiResult<OrderDTOResponse>.SuccesWithData(orderDTOResponse));
        }

        [HttpPost("/UpdateOrder")]
        public async Task<IActionResult> UpdateOrder(OrderDTORequest orderDTORequest)
        {
            Order order = await _orderService.GetAsync(x => x.Id == orderDTORequest.Id);

            order = _mapper.Map(orderDTORequest,order);

            await _orderService.UpdateAsync(order);

            return Ok(ApiResult<OrderDTOResponse>.SuccesWithOutData());
        }

        [HttpDelete("/DeleteOrder/{orderId}")]
        public async Task<IActionResult> DeleteOrder(long orderId)
        {
            var order = await _orderService.GetAsync(x=>x.Id==orderId);

            await _orderService.DeleteAsync(order);

            return Ok(ApiResult<OrderDTOResponse>.SuccesWithOutData());
        }

        [HttpGet("/Orders/{userId}")]
        public async Task<IActionResult> GetAllOrder(long userId)
        {
            var orders = await _orderService.GetAllAsync(x=>x.UserId==userId);

            List<OrderDTOResponse> orderDTOResponses = new();

            foreach (var order in orders)
            {
                orderDTOResponses.Add(_mapper.Map<OrderDTOResponse>(order));
            }

            return Ok(ApiResult<List<OrderDTOResponse>>.SuccesWithData(orderDTOResponses));
        }

        [HttpGet("/GetOrder/{orderId}")]
        public async Task<IActionResult> GetOrder(long orderId)
        {
            var order = await _orderService.GetAsync(x=>x.Id==orderId);

            OrderDTOResponse orderDTOResponse = _mapper.Map<OrderDTOResponse>(order);
            return Ok(ApiResult<OrderDTOResponse>.SuccesWithData(orderDTOResponse));
        }
        
    }
}
