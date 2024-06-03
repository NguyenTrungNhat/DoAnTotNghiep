using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MobileShop.Core.Helper;
using MobileShop.Core.Repositories.IRepository;
using MobileShop.Core.Repositories.Repository;
using Newtonsoft.Json;

namespace MobileShop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Owner)]
    public class StatisticalController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public StatisticalController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Sales(DateTime? start, DateTime? end)
        {
            if(start == null || end == null)
            {
                 start = new DateTime(2024, 1, 1);
                 end = DateTime.Now;
            }    
            var moneyData = await unitOfWork.OrderRepository.GetReportMoney(start, end);
            ViewBag.DataPoint1 = JsonConvert.SerializeObject(moneyData);
            return View();
        }

        public async Task<IActionResult> SalesProduct(DateTime? start, DateTime? end)
        {
            if (start == null || end == null)
            {
                start = new DateTime(2024, 1, 1);
                end = DateTime.Now;
            }

            var quantityData = await unitOfWork.OrderRepository.GetReportQuantity(start, end);
            ViewBag.DataPoint = JsonConvert.SerializeObject(quantityData);

            return View();
        }

        public async Task<IActionResult> ExitsProducts()
        {
            var productData = unitOfWork.ProductRepository.GetReportProduct();
            var total = productData.Sum(x => x.Y);
            List<DataPoint> listDataPoints = new List<DataPoint>();
            foreach(var item in productData)
            {
                var temp = item.Y * 100 / total;
                DataPoint dataPoint = new DataPoint()
                {
                    label = item.label,
                    Y = Math.Round((double)temp,2)
                };
                listDataPoints.Add(dataPoint);
            }
            ViewBag.DataPoint2 = JsonConvert.SerializeObject(listDataPoints);
            ViewBag.DtPoint = JsonConvert.SerializeObject(productData);
            return View();
        }
    }
}
