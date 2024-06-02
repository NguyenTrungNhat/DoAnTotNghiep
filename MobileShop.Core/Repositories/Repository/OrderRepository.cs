using Microsoft.EntityFrameworkCore;
using MobileShop.Core.Data;
using MobileShop.Core.Helper;
using MobileShop.Core.Models;
using MobileShop.Core.Repositories.IRepository;

namespace MobileShop.Core.Repositories.Repository
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository()
        { }

        public OrderRepository(MobileShopDBContext context) : base(context)
        {
        }

        public async Task<List<DataPoint>> GetReportMoney(DateTime? start, DateTime? end)
        {
            var listData = new List<DataPoint>();
            DateTime startDate = (DateTime)start;
            DateTime endDate = (DateTime)end;

            if (start != null || end != null)
            {
                if (startDate.Month == endDate.Month)
                {
                    var orders = await entities.Where(obj => obj.DateOrder >= start && obj.DateOrder <= end && obj.OrderStatus == "Thành công").ToListAsync();
                    var data = (double)orders.Sum(x => x.TotalPrice);
                    DataPoint dataPoint = new DataPoint(startDate.ToString("MM/yyyy"), data);
                    listData.Add(dataPoint);
                }
                else
                {
                    var tempEmdDate = endDate.AddMonths(1);
                    while (startDate.Month != tempEmdDate.Month)
                    {
                        var endOfMonth = new DateTime(startDate.Year, startDate.Month, 1).AddMonths(1);
                        endOfMonth = endOfMonth.AddDays(-1);
                        var orders = await entities.Where(obj => obj.DateOrder >= startDate && obj.DateOrder <= endOfMonth && obj.OrderStatus == "Thành công").ToListAsync();
                        var data = (double)orders.Sum(x => x.TotalPrice);

                        DataPoint dataPoint = new DataPoint(startDate.ToString("MM/yyyy"), data);
                        listData.Add(dataPoint);
                        startDate = startDate.AddMonths(1);
                    }

                }    
            }
            return listData;
        }

        public async Task<List<DataPoint>> GetReportQuantity(DateTime? start, DateTime? end)
        {
            var listData = new List<DataPoint>();
            DateTime startDate = (DateTime)start;
            DateTime endDate = (DateTime)end;

            //var orders = entities.Where(x => x.OrderStatus == "Thành công").ToList();
            if (start != null || end != null)
            {
                if (startDate.Month == endDate.Month)
                {
                    var orders = await entities.Where(obj => obj.DateOrder >= start && obj.DateOrder <= end && obj.OrderStatus == "Thành công").ToListAsync();
                    var data = orders.Join(context.OrderDetail,
                    ord => ord.OrderId,
                    odetail => odetail.OrderId,
                    (ord, odetail) => new
                    {
                        Quantity = odetail.Quantity,
                    }
                    ).ToList().Sum(a => a.Quantity);

                    DataPoint dataPoint = new DataPoint(startDate.ToString("MM/yyyy"), data);
                    listData.Add(dataPoint);
                }
                else
                {
                    var tempEmdDate = endDate.AddMonths(1);
                    while (startDate.Month != tempEmdDate.Month)
                    {
                        var endOfMonth = new DateTime(startDate.Year, startDate.Month, 1).AddMonths(1);
                        endOfMonth = endOfMonth.AddDays(-1);
                        var orders =await entities.Where(obj => obj.DateOrder >= startDate && obj.DateOrder <= endOfMonth && obj.OrderStatus == "Thành công").ToListAsync();
                        var data = orders.Join(context.OrderDetail,
                        ord => ord.OrderId,
                        odetail => odetail.OrderId,
                        (ord, odetail) => new
                        {
                            Quantity = odetail.Quantity,
                        }
                        ).ToList().Sum(a => a.Quantity);

                        DataPoint dataPoint = new DataPoint(startDate.ToString("MM/yyyy"), data);
                        listData.Add(dataPoint);
                        startDate = startDate.AddMonths(1);
                    }
                }    
            }
            return listData;
        }
    }
}
