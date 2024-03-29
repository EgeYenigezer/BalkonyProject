﻿using AutoMapper;
using BalkonyApi.Aspects;
using BalkonyApi.Validation.FluentValidation;
using BalkonyBusiness.Abstract;
using BalkonyBusiness.Cache;
using BalkonyEntity.DTO.Product;
using BalkonyEntity.Poco;
using BalkonyEntity.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;


namespace BalkonyApi.Controllers
{
    [ApiController]
    [Route("[Action]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        private readonly ICacheService _cacheService;
        private readonly IMemoryCache _memoryCache;

        public ProductController(IProductService productService, IMapper mapper, ICacheService cacheService, IMemoryCache memoryCache)
        {
            _productService = productService;
            _mapper = mapper;
            _cacheService = cacheService;
            _memoryCache = memoryCache;
        }

        [HttpPost("/AddProduct")]
        [ValidationFilter(typeof(ProductValidator))]
        public async Task<IActionResult> AddProduct(ProductDTORequest productDTORequest)
        {
            Product product = _mapper.Map<Product>(productDTORequest);

            await _productService.AddAsync(product);

            ProductDTOResponse productDTOResponse = _mapper.Map<ProductDTOResponse>(product);

            return Ok(ApiResult<ProductDTOResponse>.SuccesWithData(productDTOResponse));
        }

        [HttpPost("/UpdateProduct")]
        [ValidationFilter(typeof(ProductValidator))]
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
        [CacheAspect(60)]
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

            ProductDTOResponse productDTOResponse = _mapper.Map<ProductDTOResponse>(await _productService.GetAsync(x => x.Id == productId));


            return Ok(ApiResult<ProductDTOResponse>.SuccesWithData(productDTOResponse));
        }
    }
}
