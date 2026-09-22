using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Flower_Shop.Data;
using System.Security.Claims;

namespace Flower_Shop.Controllers
{
    public class AccountsController : Controller
    {
        private readonly AppDbContext _db;

        public AccountsController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(
            string username,
            string password)
        {
            var user = _db.Users
                .FirstOrDefault(u => u.Username == username);

            if (user != null &&
                BCrypt.Net.BCrypt.Verify(
                    password,
                    user.PasswordHash))
            {
                var claims = new List<Claim>
                {
                    new Claim(
                        ClaimTypes.Name,
                        user.Username),

                    new Claim(
                        "UserId",
                        user.Id.ToString())
                };

                var identity = new ClaimsIdentity(
                    claims,
                    "MyCookieAuth");

                var principal =
                    new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(
                    "MyCookieAuth",
                    principal);

                return RedirectToAction(
                    "Index",
                    "Home");
            }

            ModelState.AddModelError(
                "",
                "Invalid username or password");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(
                "MyCookieAuth");

            return RedirectToAction(
                nameof(Login));
        }
    }
}