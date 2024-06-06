using Microsoft.EntityFrameworkCore;
using MobileShop.Core.Data;
using MobileShop.Core.Helper;
using MobileShop.Core.Models;
using MobileShop.Core.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileShop.Core.Repositories.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository()
        { }

        public ProductRepository(MobileShopDBContext context) : base(context)
        {
        }

        public async Task<List<Product>> GetByCategoryId(int id)
        {
            var products = await entities.Where(x=> x.CategoryId== id).ToListAsync();
            return products;
        }

        public string GetCategoryName(int id)
        {
            var category = context.Categorys.Find(id);
            return category.CategoryName;
        }

        public async Task<List<Product>> SearchProductName(string key)
        {
            var products = new List<Product>();
            if (!String.IsNullOrEmpty(key))
            {
                products = await entities.Where(x => x.ProductName.ToUpper().Contains(key.ToUpper())).ToListAsync();
            }
            return products;
        }

        public List<DataPoint> GetReportProduct()
        {
            var listData = new List<DataPoint>();
            var categories = context.Categorys.ToList();
            var products = entities.ToList();
            foreach (var category in categories)
            {
                var count = (double)products.Where(x => x.CategoryId == category.CategoryId).Sum(u => u.Quantity);
                DataPoint dataPoint = new DataPoint(category.CategoryName, count);
                listData.Add(dataPoint);
            }
            return listData;
        }
    }
}
