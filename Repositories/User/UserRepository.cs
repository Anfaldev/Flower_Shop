using System;
using Flower_Shop.Data;
using Flower_Shop.Models;
using Microsoft.EntityFrameworkCore;

namespace Flower_Shop.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _db;
        private readonly DbSet<User> _dbSet;

        public UserRepository(AppDbContext db)
        {
            _db = db;
            _dbSet = _db.Set<User>();
        }

        public void Add(User user)
        {
            _dbSet.Add(user);
        }

        public void Delete(User user)
        {
            _dbSet.Remove(user);
        }

        public IEnumerable<User> GetAll()
        {
            return _dbSet.ToList();
        }

        public User? GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public User? GetByUId(string uid)
        {
            return _dbSet.FirstOrDefault(e => e.UID == uid);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(User user)
        {
            _dbSet.Update(user);
        }
    }
}

