using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MobileShop.Core.Helper;
using MobileShop.Core.Repositories.IRepository;
using MobileShop.Web.Areas.Admin.Models;

namespace MobileShop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Owner)]
    public class UsersController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly UserManager<IdentityUser> userManager;

        public UsersController(IUnitOfWork unitOfWork, UserManager<IdentityUser> userManager)
        {
            this.unitOfWork = unitOfWork;
            this.userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var users = await unitOfWork.UserRepository.GetAllAsync();
            var usersDTO = new List<UserDTO>();
            foreach (var item in users)
            {
                var role = await userManager.GetRolesAsync(item);
                var userDTO = new UserDTO()
                {
                    Name = item.UserName,
                    Email = item.Email,
                    Id = item.Id,
                    Role = string.Join(", ", role)
                };
                usersDTO.Add(userDTO);
            }
            return View(usersDTO);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserDTO userDTO)
        {
            var passwordHasher = new PasswordHasher<IdentityUser>();
            var newUser = new IdentityUser
            {
                UserName = userDTO.Name,
                Email = userDTO.Email,
                EmailConfirmed = true,
            };
            newUser.NormalizedUserName = newUser.UserName.ToUpper();
            newUser.NormalizedEmail = newUser.Email.ToUpper();
            newUser.PasswordHash = passwordHasher.HashPassword(newUser, userDTO.Password);
            await userManager.CreateAsync(newUser);
            await userManager.AddToRoleAsync(newUser, userDTO.Role);
            TempData["SuccessMessage"] = "Thêm người dùng thành công";
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            var user = unitOfWork.UserRepository.GetById(id);
            var role = await userManager.GetRolesAsync(user);
            var userDTO = new UserDTO()
            {
                Id = user.Id,
                Name = user.UserName,
                Email = user.Email,
                Role = string.Join(", ", role)
            };
            return View(userDTO);
        }

        public async Task<IActionResult> Update(UserDTO userDTO)
        {
            var passwordHasher = new PasswordHasher<IdentityUser>();
            var user =await userManager.FindByIdAsync(userDTO.Id);   
            var token = await userManager.GeneratePasswordResetTokenAsync(user);
            var result = await userManager.ResetPasswordAsync(user, token, userDTO.Password);
            var roles = await userManager.GetRolesAsync(user);
            await userManager.AddToRoleAsync(user, userDTO.Role);
            if (roles.Count != 0)
            {
                await userManager.RemoveFromRoleAsync(user, roles[0]);
            }
            TempData["SuccessMessage"] = "Cập nhật thông tin thành công";
            return Redirect("/Admin/Users");
        }
    }
}
