using System;
using Flower_Shop.Data;
using Flower_Shop.Models;
using Microsoft.EntityFrameworkCore;

namespace Flower_Shop.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _db;
        private readonly DbSet<Product> _dbSet;

        public ProductRepository(AppDbContext db)
        {
            _db = db;
            _dbSet = _db.Set<Product>();
        }

        public void Add(Product product)
        {
            _dbSet.Add(product);
        }

        public void Delete(Product product)
        {
            _dbSet.Remove(product);
        }

        public IEnumerable<Product> GetAll()
        {
            return _dbSet.ToList();
        }

        public Product? GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public Product? GetByUId(string uid)
        {
            return _dbSet.FirstOrDefault(e => e.UID == uid);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Product product)
        {
            _dbSet.Update(product);
        }
    }
}

