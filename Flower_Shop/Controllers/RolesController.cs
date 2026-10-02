using Microsoft.AspNetCore.Mvc;
using Flower_Shop.Infrastructure.Repositories;
using Flower_Shop.Infrastructure.Data;
using Flower_Shop.Application.Dtos.RolesDtos;
using Flower_Shop.Domain.Models;

namespace Flower_Shop.Controllers
{
    public class RolesController : Controller
    {
        private readonly IRoleRepository _repository;
        private readonly AppDbContext _db;

        public RolesController(
            IRoleRepository repository,
            AppDbContext db)
        {
            _repository = repository;
            _db = db;
        }

    
        public IActionResult Index()
        {
            var roles = _repository
                .GetAll()
                .Select(r => new RoleDto
                {
                    Id = r.Id,
                    UID = r.UID,
                    Name = r.Name
                })
                .ToList();

            return View(roles);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateRoleDto dto)
        {
            if (ModelState.IsValid)
            {
                Role role = new Role
                {
                    Name = dto.Name
                };

                _repository.Add(role);
                _repository.Save();
            }

            return RedirectToAction(nameof(Index));
        }

 
        [HttpGet]
        public IActionResult Edit(string uid)
        {
            var role = _repository.GetByUId(uid);

            if (role == null)
            {
                return NotFound();
            }

            var dto = new UpdateRoleDto
            {
                Id = role.Id,
                UID = role.UID,
                Name = role.Name
            };

            return View(dto);
        }

        [HttpPost]
        public IActionResult Edit(UpdateRoleDto dto)
        {
            if (ModelState.IsValid)
            {
                var role = _repository.GetById(dto.Id);

                if (role == null)
                {
                    return NotFound();
                }

                role.Name = dto.Name;

                _repository.Update(role);
                _repository.Save();
            }

            return RedirectToAction(nameof(Index));
        }

  
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var role = _repository.GetById(id);

            if (role != null)
            {
                _repository.Delete(role);
                _repository.Save();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult AssignPermissions(string uid)
        {
            var role = _repository.GetByUId(uid);

            if (role == null)
            {
                return NotFound();
            }

            var allPermissions = _db.Permissions.ToList();

            var assignedPermissions = _db.PermissionRoles
                .Where(pr => pr.RoleId == role.Id)
                .Select(pr => pr.PermissionId)
                .ToList();

            ViewBag.AllPermissions = allPermissions;
            ViewBag.AssignedPermissions = assignedPermissions;

            return View(role);
        }


        [HttpPost]
        public IActionResult AssignPermissions(
            int roleId,
            List<int> permissionIds)
        {
            var role = _repository.GetById(roleId);

            if (role == null)
            {
                return NotFound();
            }

            var oldPermissions = _db.PermissionRoles
                .Where(pr => pr.RoleId == roleId)
                .ToList();

            _db.PermissionRoles.RemoveRange(oldPermissions);

            foreach (var permissionId in permissionIds)
            {
                var permissionRole = new PermissionRole
                {
                    RoleId = roleId,
                    PermissionId = permissionId
                };

                _db.PermissionRoles.Add(permissionRole);
            }

            _db.SaveChanges();

            return RedirectToAction(
                nameof(AssignPermissions),
                new
                {
                    uid = role.UID
                }
            );
        }
    }
}