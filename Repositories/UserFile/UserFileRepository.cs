using System;
using Flower_Shop.Data;
using Flower_Shop.Models;
using Microsoft.EntityFrameworkCore;

namespace Flower_Shop.Repositories
{
    public class UserFileRepository : IUserFileRepository
    {
        private readonly AppDbContext _db;
        private readonly DbSet<UserFile> _dbSet;

        public UserFileRepository(AppDbContext db)
        {
            _db = db;
            _dbSet = _db.Set<UserFile>();
        }

        public void Add(UserFile userFile)
        {
            _dbSet.Add(userFile);
        }

        public void Delete(UserFile userFile)
        {
            _dbSet.Remove(userFile);
        }

        public IEnumerable<UserFile> GetAll()
        {
            return _dbSet.ToList();
        }

        public UserFile? GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public UserFile? GetByUId(string uid)
        {
            return _dbSet.FirstOrDefault(e => e.UID == uid);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(UserFile userFile)
        {
            _dbSet.Update(userFile);
        }
    }
}

