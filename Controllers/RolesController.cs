using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Flower_Shop.Data;
using Flower_Shop.Models;

namespace Flower_Shop.Controllers
{
    public class RolesController : Controller
    {
        private readonly AppDbContext _db;

        public RolesController(AppDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            IEnumerable<Role> roles = _db.Roles.ToList();
            return View(roles);
        }



        // Create

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Role role)
        {
            if (ModelState.IsValid)
            {
                _db.Roles.Add(role);
                _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }


        // Edit
     
        [HttpPost]
        public IActionResult Edit(Role role)
        {
            if (ModelState.IsValid)
            {
                _db.Roles.Update(role);
                _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }


        // Delete
    
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var role = _db.Roles.Find(id);

            if (role != null)
            {
                _db.Roles.Remove(role);
                _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }


     
        // Assign Permissions - GET
       
        public IActionResult AssignPermissions(int roleId)
        {
            var role = _db.Roles.Find(roleId);

            if (role == null)
            {
                return NotFound();
            }

            var allPermissions = _db.Permissions.ToList();

            var assignedPermissions = _db.PermissionRoles
                .Where(pr => pr.RoleId == roleId)
                .Select(pr => pr.PermissionId)
                .ToList();

            ViewBag.AllPermissions = allPermissions;
            ViewBag.AssignedPermissions = assignedPermissions;

            return View(role);
        }


       
        // Assign Permissions - POST
      
        [HttpPost]
        public IActionResult AssignPermissions(
            int roleId,
            List<int> permissionIds)
        {
            var role = _db.Roles.Find(roleId);

            if (role == null)
            {
                return NotFound();
            }


            //Get old permissions
            var oldPermissions = _db.PermissionRoles
                .Where(pr => pr.RoleId == roleId)
                .ToList();


            //Remove old permissions
            _db.PermissionRoles.RemoveRange(oldPermissions);


            // Add permissions
            foreach (var permissionId in permissionIds)
            {
                var permissionRole = new PermissionRole
                {
                    RoleId = roleId,
                    PermissionId = permissionId
                };

                _db.PermissionRoles.Add(permissionRole);
            }


            //Save
            _db.SaveChanges();


            return RedirectToAction(
                "AssignPermissions",
                new { roleId = roleId }
            );
        }
    }
}
