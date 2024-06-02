using MobileShop.Core.Data;
using MobileShop.Core.Models;
using MobileShop.Core.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileShop.Core.Repositories.Repository
{
    public class OrderDetailRepository : GenericRepository<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository()
        { }

        public OrderDetailRepository(MobileShopDBContext context) : base(context)
        {
        }
    }
}
