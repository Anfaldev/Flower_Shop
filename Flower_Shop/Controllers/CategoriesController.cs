using Flower_Shop.Application.Dtos.CategoriesDtos;
using Flower_Shop.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Flower_Shop.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var categories = _categoryService.GetAllCategories();

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
                _categoryService.AddCategory(dto);

                return RedirectToAction(nameof(Index));
            }

            return View(dto);
        }

        public IActionResult Edit(string uid)
        {
            var category = _categoryService.GetCategoryByUid(uid);

            if (category == null)
            {
                return NotFound();
            }

            var dto = new UpdateCategoryDto
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
                var category = _categoryService.GetCategoryById(dto.Id);

                if (category == null)
                {
                    return NotFound();
                }

                _categoryService.UpdateCategory(dto);

                return RedirectToAction(nameof(Index));
            }

            return View(dto);
        }

        public IActionResult Delete(string uid)
        {
            var category = _categoryService.GetCategoryByUid(uid);

            if (category == null)
            {
                return NotFound();
            }

            var deleted = _categoryService.DeleteCategory(uid);

            if (!deleted)
            {
                TempData["DeleteError"] =
                    "Cannot delete this category because it has products.";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}