using Microsoft.AspNetCore.Mvc;
using Flower_Shop.Data;

namespace Flower_Shop.Controllers
{
    public class AccountsController : Controller
    {
        private readonly AppDbContext _db;

        public AccountsController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = _db.Users
                .FirstOrDefault(u => u.Username == username);

            if (user != null &&
                BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(
                    "",
                    "Invalid username or password");

                return View();
            }
        }
    }
}