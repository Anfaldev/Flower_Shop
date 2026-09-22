using System;
using Flower_Shop.Data;
using Flower_Shop.Models;
using Microsoft.EntityFrameworkCore;

namespace Flower_Shop.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly AppDbContext _db;
        private readonly DbSet<OrderItem> _dbSet;

        public OrderItemRepository(AppDbContext db)
        {
            _db = db;
            _dbSet = _db.Set<OrderItem>();
        }

        public void Add(OrderItem orderItem)
        {
            _dbSet.Add(orderItem);
        }

        public void Delete(OrderItem orderItem)
        {
            _dbSet.Remove(orderItem);
        }

        public IEnumerable<OrderItem> GetAll()
        {
            return _dbSet.ToList();
        }

        public OrderItem? GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public OrderItem? GetByUId(string uid)
        {
            return _dbSet.FirstOrDefault(e => e.UID == uid);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(OrderItem orderItem)
        {
            _dbSet.Update(orderItem);
        }
    }
}

