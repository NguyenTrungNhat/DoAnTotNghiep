using MobileShop.Core.Data;
using MobileShop.Core.Repositories.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileShop.Core.Repositories.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository CategoryRepository { get; }
        IOrderRepository OrderRepository { get; }
        IProductRepository ProductRepository { get; }
        IOrderDetailRepository OrderDetailRepository { get; }
        IUserRepository UserRepository { get; }
        IUserCartRepository UserCartRepository { get; }
        MobileShopDBContext MobileShopDBContext { get; }

        int SaveChange();

        Task<int> SaveChangeAsync();
    }
}
