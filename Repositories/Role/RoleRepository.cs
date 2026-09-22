using System;
using Flower_Shop.Data;
using Flower_Shop.Models;
using Microsoft.EntityFrameworkCore;

namespace Flower_Shop.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AppDbContext _db;
        private readonly DbSet<Role> _dbSet;

        public RoleRepository(AppDbContext db)
        {
            _db = db;
            _dbSet = _db.Set<Role>();
        }

        public void Add(Role role)
        {
            _dbSet.Add(role);
        }

        public void Delete(Role role)
        {
            _dbSet.Remove(role);
        }

        public IEnumerable<Role> GetAll()
        {
            return _dbSet.ToList();
        }

        public Role? GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public Role? GetByUId(string uid)
        {
            return _dbSet.FirstOrDefault(e => e.UID == uid);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Role role)
        {
            _dbSet.Update(role);
        }
    }
}
