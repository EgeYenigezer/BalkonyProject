using BalkonyDAL.Abstract;
using BalkonyDAL.Abstract.DataManagement;
using BalkonyDAL.Concrete.EntityFramework.Context;
using BalkonyEntity.Poco.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalkonyDAL.Concrete.EntityFramework.DataManagement
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly BalconyDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;

        public EfUnitOfWork(BalconyDbContext context, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _contextAccessor = contextAccessor;

            CustomerRepository = new EfCustomerRepository(_context);
            OrderRepository = new EfOrderRepository(_context);
            ProductRepository = new EfProductRepository(_context);
            StockRepository = new EfStockRepository(_context);
            StockDetailRepository = new EfStockDetailRepository(_context);
            SupplierRepository = new EfSupplierRepository(_context);
            UserRepository = new EfUserRepository(_context);
        }


        public ICustomerRepository CustomerRepository { get;}

        public IOrderRepository OrderRepository { get; }

        public IProductRepository ProductRepository { get; }

        public IStockRepository StockRepository { get; }

        public IStockDetailRepository StockDetailRepository { get; }

        public ISupplierRepository SupplierRepository { get; }

        public IUserRepository UserRepository { get; }

        public async Task<int> SaveChangeAsync()
        {
            foreach (var item in _context.ChangeTracker.Entries<BaseEntity>())
            {
                if (item.State== EntityState.Added)
                {
                    item.Entity.AddedTime = DateTime.Now;
                    item.Entity.UpdatedTime = DateTime.Now;
                    if (item.Entity.IsActive==null)
                    {
                        item.Entity.IsActive = true;
                    }
                }
                if (item.State == EntityState.Modified)
                {
                    item.Entity.UpdatedTime = DateTime.Now;
                }

            }
            return _context.SaveChanges();
        }
    }
}
