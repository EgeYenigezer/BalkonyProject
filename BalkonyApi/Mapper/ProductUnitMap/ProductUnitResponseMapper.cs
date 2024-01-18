﻿using AutoMapper;
using BalkonyEntity.DTO.ProductUnit;
using BalkonyEntity.Poco;

namespace BalkonyApi.Mapper.ProductUnitMap
{
    public class ProductUnitResponseMapper:Profile
    {
        public ProductUnitResponseMapper()
        {
            CreateMap<ProductUnit, ProductUnitDTOResponse>();
            CreateMap<ProductUnitDTOResponse, ProductUnit>();
        }
    }
}
