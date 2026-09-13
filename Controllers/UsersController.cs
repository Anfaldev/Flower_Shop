using Microsoft.AspNetCore.Mvc;
using Flower_Shop.Data;
using Flower_Shop.Models;

namespace Flower_Shop.Controllers
{
    public class UsersController : Controller
    {
        private readonly AppDbContext _db;

        public UsersController(AppDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            IEnumerable<User> users = _db.Users.ToList();
            return View(users);
        }


        // Create
 
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.Password);

                _db.Users.Add(user);
                _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }



        // Edit

        public IActionResult Edit(int id)
        {
            var user = _db.Users.Find(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                _db.Users.Update(user);
                _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }


        // Delete
      
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var user = _db.Users.Find(id);

            if (user != null)
            {
                _db.Users.Remove(user);
                _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }


        
        // Assign Roles - GET
      
        public IActionResult AssignRoles(int userId)
        {
            var user = _db.Users.Find(userId);

            if (user == null)
            {
                return NotFound();
            }

            var allRoles = _db.Roles.ToList();

            var assignedRoles = _db.RoleUsers
                .Where(ru => ru.UserId == userId)
                .Select(ru => ru.RoleId)
                .ToList();

            ViewBag.AllRoles = allRoles;
            ViewBag.AssignedRoles = assignedRoles;

            return View(user);
        }


      
        // Assign Roles - POST
     
        [HttpPost]
        public IActionResult AssignRoles(
            int userId,
            List<int> roleIds)
        {
            var user = _db.Users.Find(userId);

            if (user == null)
            {
                return NotFound();
            }


            // Get old roles
            var oldRoles = _db.RoleUsers
                .Where(ru => ru.UserId == userId)
                .ToList();


            // Remove old roles
            _db.RoleUsers.RemoveRange(oldRoles);


            // Add selected roles
            foreach (var roleId in roleIds)
            {
                var roleUser = new RoleUser
                {
                    UserId = userId,
                    RoleId = roleId
                };

                _db.RoleUsers.Add(roleUser);
            }


            // Save
            _db.SaveChanges();


            return RedirectToAction(
                "AssignRoles",
                new { userId = userId }
            );
        }
    }
}

