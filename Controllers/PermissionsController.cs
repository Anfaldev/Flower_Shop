using Microsoft.AspNetCore.Mvc;
using Flower_Shop.Models;
using Flower_Shop.Dtos.PermissionsDtos;
using Flower_Shop.Repositories;

namespace Flower_Shop.Controllers
{
    public class PermissionsController : Controller
    {
        private readonly IPermissionRepository _repository;

        public PermissionsController(IPermissionRepository repository)
        {
            _repository = repository;
        }

        // =========================
        // Index
        // =========================
        [HttpGet]
        public IActionResult Index()
        {
            var permissions = _repository
                .GetAll()
                .Select(p => new PermissionDto
                {
                    Id = p.Id,
                    UID = p.UID,
                    Name = p.Name
                })
                .ToList();

            return View(permissions);
        }

        // =========================
        // Create
        // =========================
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreatePermissionDto dto)
        {
            if (ModelState.IsValid)
            {
                Permission permission = new Permission
                {
                    Name = dto.Name
                };

                _repository.Add(permission);
                _repository.Save();

                return RedirectToAction(nameof(Index));
            }

            return View(dto);
        }

        // =========================
        // Edit
        // =========================
        [HttpGet]
        public IActionResult Edit(string uid)
        {
            var permission = _repository.GetByUId(uid);

            if (permission == null)
            {
                return NotFound();
            }

            UpdatePermissionDto dto = new UpdatePermissionDto
            {
                Id = permission.Id,
                UID = permission.UID,
                Name = permission.Name
            };

            return View(dto);
        }

        [HttpPost]
        public IActionResult Edit(UpdatePermissionDto dto)
        {
            if (ModelState.IsValid)
            {
                var permission = _repository.GetById(dto.Id);

                if (permission == null)
                {
                    return NotFound();
                }

                permission.Name = dto.Name;

                _repository.Update(permission);
                _repository.Save();

                return RedirectToAction(nameof(Index));
            }

            return View(dto);
        }

        // =========================
        // Delete
        // =========================
        [HttpGet]
        public IActionResult Delete(string uid)
        {
            var permission = _repository.GetByUId(uid);

            if (permission == null)
            {
                return NotFound();
            }

            PermissionDto dto = new PermissionDto
            {
                Id = permission.Id,
                UID = permission.UID,
                Name = permission.Name
            };

            return View(dto);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var permission = _repository.GetById(id);

            if (permission == null)
            {
                return NotFound();
            }

            _repository.Delete(permission);
            _repository.Save();

            return RedirectToAction(nameof(Index));
        }
    }
}