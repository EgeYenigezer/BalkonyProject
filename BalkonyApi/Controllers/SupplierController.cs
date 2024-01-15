using AutoMapper;
using BalkonyApi.Aspects;
using BalkonyApi.Validation.FluentValidation;
using BalkonyBusiness.Abstract;
using BalkonyEntity.DTO.Supplier;
using BalkonyEntity.Poco;
using BalkonyEntity.Result;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BalkonyApi.Controllers
{
    [ApiController]
    [Route("[Action]")]
    public class SupplierController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService, IMapper mapper)
        {
            _supplierService = supplierService;
            _mapper = mapper;
        }

        [HttpPost("/AddSupplier")]
        [ValidationFilter(typeof (SupplierValidator))]
        public async Task<IActionResult> AddSupplier(SupplierDTORequest supplierDTORequest)
        {
            Supplier supplier = new();
            supplier = _mapper.Map<Supplier>(supplierDTORequest);

            await _supplierService.AddAsync(supplier);

            SupplierDTOResponse supplierDTOResponse = _mapper.Map<SupplierDTOResponse>(supplier);
            

            return Ok(ApiResult<SupplierDTOResponse>.SuccesWithData(supplierDTOResponse));
        }

        [HttpPost("/UpdateSupplier")]
        [ValidationFilter(typeof(SupplierValidator))]
        public async Task<IActionResult> UpdateSupplier(SupplierDTORequest supplierDTORequest)
        {
            var supplier = await _supplierService.GetAsync(x => x.Id == supplierDTORequest.Id);

            supplier = _mapper.Map(supplierDTORequest,supplier);

            await _supplierService.UpdateAsync(supplier);

            return Ok(ApiResult<SupplierDTOResponse>.SuccesWithOutData());

        }

        [HttpDelete("/DeleteSupplier/{supplierId}")]
        public async Task<IActionResult> DeleteSupplier(long supplierId)
        {
            var supplier = await _supplierService.GetAsync(x=>x.Id==supplierId);

            await _supplierService.DeleteAsync(supplier);

            return Ok(ApiResult<SupplierDTOResponse>.SuccesWithOutData());
        }

        [HttpGet("/Suppliers/{userId}")]
        public async Task<IActionResult> GetAllSupplier(long userId)
        {
            var suppliers = await _supplierService.GetAllAsync(x=>x.UserId==userId);

            List<SupplierDTOResponse> supplierDTOResponses = new();
            foreach (var supplier in suppliers)
            {
                supplierDTOResponses.Add(_mapper.Map<SupplierDTOResponse>(supplier));
            }

            return Ok(ApiResult<List<SupplierDTOResponse>>.SuccesWithData(supplierDTOResponses));
        }

        [HttpGet("/GetSupplier/{supplierId}")]
        public async Task<IActionResult> GetSupplier(long supplierId)
        {
            var supplier = await _supplierService.GetAsync(x => x.Id == supplierId);

            SupplierDTOResponse supplierDTOResponse = _mapper.Map<SupplierDTOResponse>(supplier);

            return Ok(ApiResult<SupplierDTOResponse>.SuccesWithData(supplierDTOResponse));
        }
    }
}
