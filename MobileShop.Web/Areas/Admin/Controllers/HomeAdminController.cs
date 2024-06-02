using Microsoft.AspNetCore.Mvc;
using MobileShop.Core.Models;
using MobileShop.Core.Repositories.IRepository;
using MobileShop.Web.Models;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MobileShop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeAdminController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public HomeAdminController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            var start = new DateTime(2023, 5, 1);
            var ed = new DateTime(2023, 9, 15);
            var product = await unitOfWork.ProductRepository.GetAllAsync();
            var productData = unitOfWork.ProductRepository.GetReportProduct();

            ViewBag.DataPoint2 = JsonConvert.SerializeObject(productData);

            var quantityData = await unitOfWork.OrderRepository.GetReportQuantity(start, ed);
            ViewBag.DataPoint = JsonConvert.SerializeObject(quantityData);

            var moneyData = await unitOfWork.OrderRepository.GetReportMoney(start, ed);
            ViewBag.DataPoint1 = JsonConvert.SerializeObject(moneyData);

            return View();
        }
    }
}
