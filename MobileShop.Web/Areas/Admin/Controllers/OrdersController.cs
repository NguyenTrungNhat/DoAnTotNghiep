using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MobileShop.Core.Helper;
using MobileShop.Core.Repositories.IRepository;
using System.Data;

namespace MobileShop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Employee + "," + SD.Role_Owner)]
    public class OrdersController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public OrdersController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            var orders =await unitOfWork.OrderRepository.GetAllAsync();
            return View(orders);
        }

        public async Task<IActionResult> Confirm(int id)
        {
            var order =await unitOfWork.OrderRepository.GetByIdAsync(id);
            order.OrderStatus = "Thành công";
            var orderDetail = unitOfWork.OrderDetailRepository.GetByWhereAsync(x => x.OrderId == order.OrderId).ToList();
            foreach (var item in orderDetail)
            {
                var product = await unitOfWork.ProductRepository.GetByIdAsync(item.ProductId);
                product.Quantity -= item.Quantity;
            }
            unitOfWork.SaveChange();
            TempData["SuccessMessage"] = "Cập nhật thành công";
            return Redirect("/Admin/Orders");
        }

        public async Task<IActionResult> Shipping(int id)
        {
            var order = await unitOfWork.OrderRepository.GetByIdAsync(id);
            order.OrderStatus = "Đang giao hàng";
            var orderDetail = unitOfWork.OrderDetailRepository.GetByWhereAsync(x => x.OrderId == order.OrderId).ToList();
            unitOfWork.SaveChange();
            TempData["SuccessMessage"] = "Cập nhật thành công";
            return Redirect("/Admin/Orders");
        }
    }
}
