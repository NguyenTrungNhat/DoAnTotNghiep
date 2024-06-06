using Microsoft.AspNetCore.Mvc;
using MobileShop.Core.Models;
using MobileShop.Core.Repositories.Repository;
using MobileShop.Web.Models;
using System.Diagnostics;
using MobileShop.Core.Repositories.IRepository;
using MobileShop.Core.Helper;
using Microsoft.AspNetCore.Identity;

namespace MobileShop.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            this.unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> SearchProductName(string form1)
        {
            try
            {
                var product = await unitOfWork.ProductRepository.SearchProductName(form1);
                return View(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}