using Flower_Shop.Domain.Models;
using Flower_Shop.Infrastructure.Data;
using Flower_Shop.Models;

namespace Flower_Shop.Infrastructure.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly AppDbContext _db;

        public OrderItemRepository(AppDbContext db)
        {
            _db = db;
        }

        public IEnumerable<OrderItem> GetAll()
        {
            return _db.OrderItems.ToList();
        }

        public OrderItem? GetById(int id)
        {
            return _db.OrderItems.Find(id);
        }

        public OrderItem? GetByUId(string uid)
        {
            return _db.OrderItems
                .FirstOrDefault(o => o.UID == uid);
        }

        public void Add(OrderItem orderItem)
        {
            _db.OrderItems.Add(orderItem);
        }

        public void Update(OrderItem orderItem)
        {
            _db.OrderItems.Update(orderItem);
        }

        public void Delete(OrderItem orderItem)
        {
            _db.OrderItems.Remove(orderItem);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}