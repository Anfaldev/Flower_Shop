using Flower_Shop.Models;
using Flower_Shop.Dtos.CategoriesDtos;
using Flower_Shop.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Flower_Shop.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryRepository _repository;

        public CategoriesController(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var categories = _repository
                .GetAll()
                .Select(c => new CategoryDto
                {
                    Id = c.Id,
                    UID = c.UID,
                    Name = c.Name
                })
                .ToList();

            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateCategoryDto dto)
        {
            if (ModelState.IsValid)
            {
                Category category = new Category
                {
                    Name = dto.Name
                };

                _repository.Add(category);
                _repository.Save();

                return RedirectToAction("Index");
            }

            return View(dto);
        }

        public IActionResult Edit(string uid)
        {
            var category = _repository.GetByUId(uid);

            if (category == null)
            {
                return NotFound();
            }

            UpdateCategoryDto dto = new UpdateCategoryDto
            {
                Id = category.Id,
                UID = category.UID,
                Name = category.Name
            };

            return View(dto);
        }

        [HttpPost]
        public IActionResult Edit(UpdateCategoryDto dto)
        {
            if (ModelState.IsValid)
            {
                var category = _repository.GetById(dto.Id);

                if (category == null)
                {
                    return NotFound();
                }

                category.Name = dto.Name;

                _repository.Update(category);
                _repository.Save();

                return RedirectToAction("Index");
            }

            return View(dto);
        }

        public IActionResult Delete(string uid)
        {
            var category = _repository.GetByUId(uid);

            if (category == null)
            {
                return NotFound();
            }

            _repository.Delete(category);
            _repository.Save();

            return RedirectToAction("Index");
        }
    }
}