using Flower_Shop.Application.Dtos.ProductsDtos;
using Flower_Shop.Domain.Models;


namespace Flower_Shop.Application.Services
{
    public interface IProductService
    {
        IEnumerable<ProductDto> GetAllProducts();

        Product? GetProductById(int id);

        Product? GetProductByUid(string uid);

        IEnumerable<Category> GetAllCategories();

        void AddProduct(CreateProductDto dto);

        void UpdateProduct(UpdateProductDto dto);

        void DeleteProduct(int id);
    }
}