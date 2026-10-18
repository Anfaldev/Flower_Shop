using Microsoft.AspNetCore.Mvc;
using Flower_Shop.Application.Services;
using Flower_Shop.Application.Dtos.CategoriesDtos;

namespace Flower_Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var categories = _categoryService.GetAllCategories();

            return Ok(categories);
        }
    }
}