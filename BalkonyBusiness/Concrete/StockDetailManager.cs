﻿using BalkonyBusiness.Abstract;
using BalkonyDAL.Abstract.DataManagement;
using BalkonyEntity.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BalkonyBusiness.Concrete
{
    public class StockDetailManager : IStockDetailService
    {
        private readonly IUnitOfWork _uow;

        public StockDetailManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<StockDetail> AddAsync(StockDetail Entity)
        {
            await _uow.StockDetailRepository.AddAsync(Entity);
            await _uow.SaveChangeAsync();
            return Entity;
        }

        public async Task DeleteAsync(StockDetail Entity)
        {
            await _uow.StockDetailRepository.RemoveAsync(Entity);
            await _uow.SaveChangeAsync();
        }

        public async Task<IEnumerable<StockDetail>> GetAllAsync(Expression<Func<StockDetail, bool>> Filter = null, params string[] IncludeProperties)
        {
            return await _uow.StockDetailRepository.GetAllAsync(Filter, IncludeProperties);
        }

        public async Task<StockDetail> GetAsync(Expression<Func<StockDetail, bool>> Filter, params string[] IncludeProperties)
        {
            return await _uow.StockDetailRepository.GetAsync(Filter, IncludeProperties);
        }

        public async Task UpdateAsync(StockDetail Entity)
        {
            await _uow.StockDetailRepository.UpdateAsync(Entity);
            await _uow.SaveChangeAsync();
        }
    }
}
