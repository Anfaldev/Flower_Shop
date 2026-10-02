using Flower_Shop.Application.Dtos.CategoriesDtos;
using Flower_Shop.Domain.Models;

namespace Flower_Shop.Application.Services
{
    public interface ICategoryService
    {
        IEnumerable<CategoryDto> GetAllCategories();

        Category? GetCategoryById(int id);

        Category? GetCategoryByUid(string uid);

        void AddCategory(CreateCategoryDto dto);

        void UpdateCategory(UpdateCategoryDto dto);

        bool DeleteCategory(string uid);
    }
}

