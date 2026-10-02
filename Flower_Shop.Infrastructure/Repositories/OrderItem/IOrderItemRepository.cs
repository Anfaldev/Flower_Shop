using Flower_Shop.Domain.Models;
using Flower_Shop.Models;

namespace Flower_Shop.Infrastructure.Repositories
{
    public interface IOrderItemRepository
    {
        IEnumerable<OrderItem> GetAll();
        OrderItem? GetById(int id);
        OrderItem? GetByUId(string uid);
        void Add(OrderItem orderItem);
        void Update(OrderItem orderItem);
        void Delete(OrderItem orderItem);
        void Save();
    }
}