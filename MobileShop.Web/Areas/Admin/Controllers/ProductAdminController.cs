using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MobileShop.Core.Helper;
using MobileShop.Core.Models;
using MobileShop.Core.Repositories.IRepository;

namespace MobileShop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Employee + "," + SD.Role_Owner)]
    public class ProductAdminController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public ProductAdminController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            var product = await unitOfWork.ProductRepository.GetAllAsync();
            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product, IFormFile image)
        {
            try
            {
                if (image != null)
                {
                    String filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "assets/images", image.FileName);
                    using (var file = new FileStream(filepath, FileMode.Create))
                    {
                        image.CopyTo(file);
                    }
                    product.Image = image.FileName;
                }
                await unitOfWork.ProductRepository.CreateAsync(product);
                TempData["SuccessMessage"] = "Thêm sản phẩm thành công";
                //return Redirect("/admin/productadmin");
                return View();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var product = await unitOfWork.ProductRepository.GetByIdAsync(id);
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Product product, IFormFile image)
        {
            if (image != null)
            {
                String filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "assets/images", image.FileName);
                using (var file = new FileStream(filepath, FileMode.Create))
                {
                    image.CopyTo(file);
                }
                product.Image = image.FileName;
            }
            await unitOfWork.ProductRepository.UpdateAsync(product);
            TempData["SuccessMessage"] = "Cập nhật sản phẩm thành công";
            return Redirect("/admin/productadmin");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await unitOfWork.ProductRepository.GetByIdAsync(id);
            await unitOfWork.ProductRepository.Deletesync(product);
            TempData["SuccessMessage"] = "Xóa sản phẩm thành công";
            return Redirect("/admin/productadmin");
        }
    }
}
