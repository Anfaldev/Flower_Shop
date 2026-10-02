using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Flower_Shop.Application.Services;

namespace Flower_Shop.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IUserService _userService;

        public AccountsController(IUserService userService)
        {
            _userService = userService;
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
            var user = _userService.GetUserByUsername(username);

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