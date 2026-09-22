using System;
using Flower_Shop.Data;
using Flower_Shop.Models;
using Microsoft.EntityFrameworkCore;

namespace Flower_Shop.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _db;
        private readonly DbSet<Order> _dbSet;

        public OrderRepository(AppDbContext db)
        {
            _db = db;
            _dbSet = _db.Set<Order>();
        }

        public void Add(Order order)
        {
            _dbSet.Add(order);
        }

        public void Delete(Order order)
        {
            _dbSet.Remove(order);
        }

        public IEnumerable<Order> GetAll()
        {
            return _dbSet.ToList();
        }

        public Order? GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public Order? GetByUId(string uid)
        {
            return _dbSet.FirstOrDefault(e => e.UID == uid);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Order order)
        {
            _dbSet.Update(order);
        }
    }
}

