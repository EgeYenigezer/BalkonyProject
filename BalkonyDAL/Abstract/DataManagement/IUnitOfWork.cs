using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalkonyDAL.Abstract.DataManagement
{
    public interface IUnitOfWork
    {
        ICustomerRepository CustomerRepository { get; }
        IOrderRepository OrderRepository { get; }
        IProductRepository ProductRepository { get; }
        IStockRepository StockRepository { get; }
        IStockDetailRepository StockDetailRepository { get; }
        ISupplierRepository SupplierRepository { get; }
        IUserRepository UserRepository { get; }
        Task<int> SaveChangeAsync();
    }
}
