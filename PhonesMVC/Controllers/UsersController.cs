using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhonesMVC.Data;
using PhonesMVC.Models;
using PhonesMVC.ViewModels;

namespace PhonesMVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly MVCDbContext _context;
        public UsersController(MVCDbContext context, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (!User.IsInRole("admin")) return View("Error");

            var users = await _context.AppUsers.ToListAsync();
            return View(users);
        }

        [HttpGet]
        public IActionResult Add()
        {
            if (!User.IsInRole("admin")) return View("Error");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddUserVM addRequest)
        {
            if (!User.IsInRole("admin")) return View("Error");

            var user = new AppUser()
            {
                Id = Guid.NewGuid().ToString(),
                Email = addRequest.Email,
                EmailConfirmed = true,
                UserName = addRequest.Email,
                Description = addRequest.Description
            };

            var newUserResponse = await _userManager.CreateAsync(user, addRequest.Password);
            if (newUserResponse.Succeeded) await _userManager.AddToRoleAsync(user, UserRoles.User);

            return RedirectToAction("Index", "Users");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeleteUserVM deleteRequests)
        {
            if (!User.IsInRole("admin")) return View("Error");

            var user = await _context.AppUsers.FindAsync(deleteRequests.Id);
            if (user == null) return View("Error");

            await _userManager.DeleteAsync(user);

            return RedirectToAction("Index", "Users");
        }
    }
}
