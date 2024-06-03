using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MobileShop.Core.Helper;
using MobileShop.Core.Repositories.IRepository;
using Microsoft.AspNetCore.Identity;
using System.Data;

namespace MobileShop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Employee + "," + SD.Role_Owner)]
    public class OrderDetailController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly UserManager<IdentityUser> userManager;

        public OrderDetailController(IUnitOfWork unitOfWork, UserManager<IdentityUser> userManager)
        {
            this.unitOfWork = unitOfWork;
            this.userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var orderDetail = await unitOfWork.OrderDetailRepository.GetAllAsync();
            return View(orderDetail);
        }

        public async Task<IActionResult> GetOrder(int id)
        {
            var orderDetail = await unitOfWork.OrderDetailRepository.GetByOrderId(id);

            return View(orderDetail);
        }
    }
}
