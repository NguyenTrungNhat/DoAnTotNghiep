using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MobileShop.Core.Helper;
using MobileShop.Core.Models;
using MobileShop.Core.Repositories.IRepository;
using System.Data;

namespace MobileShop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Employee + "," + SD.Role_Owner)]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            var category = await unitOfWork.CategoryRepository.GetAllAsync();
            return View(category);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            await unitOfWork.CategoryRepository.CreateAsync(category);
            TempData["SuccessMessage"] = "Thêm danh mục thành công";
            return Redirect("/Admin/Category");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var category = await unitOfWork.CategoryRepository.GetByIdAsync(id);
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Category newCategory)
        {
            await unitOfWork.CategoryRepository.UpdateAsync(newCategory);
            TempData["SuccessMessage"] = "Cập nhật danh mục thành công";
            return Redirect("/Admin/Category");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteCategory =await unitOfWork.CategoryRepository.GetByIdAsync(id);
            await unitOfWork.CategoryRepository.Deletesync(deleteCategory);
            TempData["SuccessMessage"] = "Xóa sản phẩm thành công";
            return Redirect("/Admin/Category");
        }
    }
}
