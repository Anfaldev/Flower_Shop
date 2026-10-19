using Flower_Shop.Application.Dtos.CartDtos;

namespace Flower_Shop.Application.Services
{
    public interface ICartService
    {
        IEnumerable<CartItemDto> GetCart(int userId);

        bool AddToCart(AddCartDto dto);

        bool RemoveFromCart(int userId, int productId);
    }
}