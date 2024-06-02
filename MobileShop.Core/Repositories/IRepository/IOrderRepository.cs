using MobileShop.Core.Helper;
using MobileShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileShop.Core.Repositories.IRepository
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<List<DataPoint>> GetReportQuantity(DateTime? start, DateTime? end);
        Task<List<DataPoint>> GetReportMoney(DateTime? start, DateTime? end);
    }
}
