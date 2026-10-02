using Flower_Shop.Domain.Models;
using Flower_Shop.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Flower_Shop.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _db;

        public OrderRepository(AppDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Order> GetAll()
        {
            return _db.Orders
                .Include(o => o.Customer)
                .ToList();
        }

        public Order? GetById(int id)
        {
            return _db.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                .FirstOrDefault(o => o.Id == id);
        }

        public Order? GetByUId(string uid)
        {
            return _db.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                .FirstOrDefault(o => o.UID == uid);
        }

        public void Add(Order order)
        {
            _db.Orders.Add(order);
        }

        public void Update(Order order)
        {
            _db.Orders.Update(order);
        }

        public void Delete(Order order)
        {
            _db.Orders.Remove(order);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}