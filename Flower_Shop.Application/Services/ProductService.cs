using Flower_Shop.Application.Dtos.ProductsDtos;
using Flower_Shop.Domain.Models;
using Flower_Shop.Infrastructure.Repositories;

namespace Flower_Shop.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<ProductDto> GetAllProducts()
        {
            var products = _unitOfWork.ProductRepo.GetAll();

            return products.Select(p => new ProductDto
            {
                Id = p.Id,
                UID = p.UID,
                Name = p.Name,
                Price = p.Price,
                Stock = p.Stock,
                ImageUrl = p.ImageUrl,
                CategoryId = p.CategoryId,
                CategoryName = _unitOfWork.CategoryRepo
                    .GetById(p.CategoryId ?? 0)?.Name
            }).ToList();
        }

        public Product? GetProductById(int id)
        {
            return _unitOfWork.ProductRepo.GetById(id);
        }

        public Product? GetProductByUid(string uid)
        {
            return _unitOfWork.ProductRepo.GetByUId(uid);
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _unitOfWork.CategoryRepo.GetAll();
        }

        public void AddProduct(CreateProductDto dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Price = dto.Price,
                Stock = dto.Stock,
                ImageUrl = dto.ImageUrl,
                CategoryId = dto.CategoryId
            };

            _unitOfWork.ProductRepo.Add(product);
            _unitOfWork.Save();
        }

        public void UpdateProduct(UpdateProductDto dto)
        {
            var product = _unitOfWork.ProductRepo.GetById(dto.Id);

            if (product == null)
            {
                return;
            }

            product.Name = dto.Name;
            product.Price = dto.Price;
            product.Stock = dto.Stock;
            product.ImageUrl = dto.ImageUrl;
            product.CategoryId = dto.CategoryId;

            _unitOfWork.ProductRepo.Update(product);
            _unitOfWork.Save();
        }

        public void DeleteProduct(int id)
        {
            var product = _unitOfWork.ProductRepo.GetById(id);

            if (product == null)
            {
                return;
            }

            _unitOfWork.ProductRepo.Delete(product);
            _unitOfWork.Save();
        }
    }
}