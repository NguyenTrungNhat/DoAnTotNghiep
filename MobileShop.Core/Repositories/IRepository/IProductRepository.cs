using MobileShop.Core.Helper;
using MobileShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileShop.Core.Repositories.IRepository
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<List<Product>> GetByCategoryId(int id);
        string GetCategoryName(int id);
        List<DataPoint> GetReportProduct();

        Task<List<Product>> SearchProductName(string key);
    }
}
