using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MobileShop.Core.Helper;
using MobileShop.Core.Repositories.IRepository;
using System.Data;

namespace MobileShop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Employee + "," + SD.Role_Owner)]
    public class OrderDetailController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public OrderDetailController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            var orderDetail = await unitOfWork.OrderDetailRepository.GetAllAsync();
            return View(orderDetail);
        }
    }
}
