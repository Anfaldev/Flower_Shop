using Flower_Shop.Application.Dtos.CartDtos;
using Flower_Shop.Domain.Models;
using Flower_Shop.Infrastructure.Repositories;

namespace Flower_Shop.Application.Services
{
    public class CartService : ICartService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CartService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<CartItemDto> GetCart(int userId)
        {
            var items = _unitOfWork.CartRepo.GetByUserId(userId);

            return items.Select(item => new CartItemDto
            {
                Id = item.Id,
                ProductId = item.ProductId,
                Name = item.Product.Name,
                Price = item.Product.Price,
                ImageUrl = item.Product.ImageUrl,
                Quantity = item.Quantity
            }).ToList();
        }

        public bool AddToCart(AddCartDto dto)
        {
            if (dto.Quantity < 1)
                return false;

            var product = _unitOfWork.ProductRepo.GetById(dto.ProductId);

            if (product == null)
                return false;

            var item = _unitOfWork.CartRepo.GetByUserAndProduct(
                dto.UserId,
                dto.ProductId
            );

            if (item == null)
            {
                item = new CartItem
                {
                    UserId = dto.UserId,
                    ProductId = dto.ProductId,
                    Quantity = dto.Quantity
                };

                _unitOfWork.CartRepo.Add(item);
            }
            else
            {
                item.Quantity += dto.Quantity;
            }

            _unitOfWork.Save();

            return true;
        }

        public bool RemoveFromCart(int userId, int productId)
        {
            var item = _unitOfWork.CartRepo.GetByUserAndProduct(
                userId,
                productId
            );

            if (item == null)
                return false;

            _unitOfWork.CartRepo.Delete(item);

            _unitOfWork.Save();

            return true;
        }
    }
}