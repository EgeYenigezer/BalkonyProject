using AutoMapper;
using BalkonyBusiness.Abstract;
using BalkonyEntity.DTO.Customer;
using BalkonyEntity.Poco;
using BalkonyEntity.Result;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace BalkonyApi.Controllers
{
    [ApiController]
    [Route("[Action]")]
    public class CustomerController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }


        [HttpPost("/AddCustomer")]
        public async Task<IActionResult> AddCustomer(CustomerDTORequest customerDTORequest)
        {

            Customer customer = _mapper.Map<Customer>(customerDTORequest);

            await _customerService.AddAsync(customer);
            CustomerDTOResponse customerDTOResponse=_mapper.Map<CustomerDTOResponse>(customer);
            
            return Ok(ApiResult<CustomerDTOResponse>.SuccesWithData(customerDTOResponse));
        }


        [HttpPost("/UpdateCustomer")]
        public async Task<IActionResult> UpdateCustomer(CustomerDTORequest customerDTORequest)
        {
            var customer = await _customerService.GetAsync(x=>x.Id== customerDTORequest.Id);

            customer = _mapper.Map(customerDTORequest, customer);

            await _customerService.UpdateAsync(customer);

            return Ok(ApiResult<CustomerDTOResponse>.SuccesWithOutData());
        }


        [HttpDelete("/DeleteCustomer/{customerId}")]
        public async Task<IActionResult> DeleteCustomer(long customerId)
        {
            var customer = await _customerService.GetAsync(x=>x.Id==customerId);

            await _customerService.DeleteAsync(customer);

            return Ok(ApiResult<CustomerDTOResponse>.SuccesWithOutData());
        }


        [HttpGet("/Customers/{userId}")]
        public async Task<IActionResult> GetAllCustomer(long userId)
        {
            var customers = await _customerService.GetAllAsync(x=>x.UserId==userId);

            List<CustomerDTOResponse> customerDTOResponses = new();

            foreach (var customer in customers)
            {
                customerDTOResponses.Add(_mapper.Map<CustomerDTOResponse>(customer));
            }


            return Ok(ApiResult<List<CustomerDTOResponse>>.SuccesWithData(customerDTOResponses));
        }

        [HttpGet("/GetCustomer/{id}")]
        public async Task<IActionResult> GetCustomer(long id)
        {
            var customer = await _customerService.GetAsync(x => x.Id == id);

            CustomerDTOResponse customerDTOResponse = _mapper.Map<CustomerDTOResponse>(customer);


            return Ok(ApiResult<CustomerDTOResponse>.SuccesWithData(customerDTOResponse));
        }

        
    }
}
