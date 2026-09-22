using System;
using Flower_Shop.Data;
using Flower_Shop.Models;
using Microsoft.EntityFrameworkCore;

namespace Flower_Shop.Repositories
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly AppDbContext _db;
        private readonly DbSet<Permission> _dbSet;

        public PermissionRepository(AppDbContext db)
        {
            _db = db;
            _dbSet = _db.Set<Permission>();
        }

        public void Add(Permission permission)
        {
            _dbSet.Add(permission);
        }

        public void Delete(Permission permission)
        {
            _dbSet.Remove(permission);
        }

        public IEnumerable<Permission> GetAll()
        {
            return _dbSet.ToList();
        }

        public Permission? GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public Permission? GetByUId(string uid)
        {
            return _dbSet.FirstOrDefault(e => e.UID == uid);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Permission permission)
        {
            _dbSet.Update(permission);
        }
    }
}

