using Flower_Shop.Application.Dtos.CategoriesDtos;
using Flower_Shop.Domain.Models;
using Flower_Shop.Infrastructure.Repositories;


namespace Flower_Shop.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<CategoryDto> GetAllCategories()
        {
            var categories = _unitOfWork.CategoryRepo.GetAll();

            return categories.Select(c => new CategoryDto
            {
                Id = c.Id,
                UID = c.UID,
                Name = c.Name
            }).ToList();
        }

        public Category? GetCategoryById(int id)
        {
            return _unitOfWork.CategoryRepo.GetById(id);
        }

        public Category? GetCategoryByUid(string uid)
        {
            return _unitOfWork.CategoryRepo.GetByUId(uid);
        }

        public void AddCategory(CreateCategoryDto dto)
        {
            var category = new Category
            {
                Name = dto.Name
            };

            _unitOfWork.CategoryRepo.Add(category);
            _unitOfWork.Save();
        }

        public void UpdateCategory(UpdateCategoryDto dto)
        {
            var category = _unitOfWork.CategoryRepo.GetById(dto.Id);

            if (category == null)
            {
                return;
            }

            category.Name = dto.Name;

            _unitOfWork.CategoryRepo.Update(category);
            _unitOfWork.Save();
        }

        public bool DeleteCategory(string uid)
        {
            var category = _unitOfWork.CategoryRepo.GetByUId(uid);

            if (category == null)
            {
                return false;
            }

            var hasProducts = _unitOfWork.ProductRepo
                .GetAll()
                .Any(p => p.CategoryId == category.Id);

            if (hasProducts)
            {
                return false;
            }

            _unitOfWork.CategoryRepo.Delete(category);
            _unitOfWork.Save();

            return true;
        }
    }
}