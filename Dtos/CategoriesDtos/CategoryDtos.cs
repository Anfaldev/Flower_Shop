using System;
namespace Flower_Shop.Dtos.CategoriesDtos
{
    public class CreateCategoryDto
    {
        public string Name { get; set; } = "";
    }

    public class UpdateCategoryDto : CreateCategoryDto
    {
        public int Id { get; set; }
        public string UID { get; set; } = "";
    }

    public class CategoryDto : UpdateCategoryDto
    {
    }
}