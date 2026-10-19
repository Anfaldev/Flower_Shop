using Flower_Shop.Domain.Models;

namespace Flower_Shop.Infrastructure.Repositories
{
    public interface ICartRepository
    {
        IEnumerable<CartItem> GetByUserId(int userId);

        CartItem? GetByUserAndProduct(int userId, int productId);

        void Add(CartItem item);

        void Delete(CartItem item);
    }
}