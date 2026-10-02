using Flower_Shop.Domain.Models;
using Flower_Shop.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Flower_Shop.Infrastructure.Repositories
{
    public class RoleUserRepository : IRoleUserRepository
    {
        private readonly AppDbContext _db;
        private readonly DbSet<RoleUser> _dbSet;

        public RoleUserRepository(AppDbContext db)
        {
            _db = db;
            _dbSet = _db.Set<RoleUser>();
        }

        public IEnumerable<RoleUser> GetAll()
        {
            return _dbSet.ToList();
        }

        public RoleUser? GetByUserIdAndRoleId(
            int userId,
            int roleId)
        {
            return _dbSet.FirstOrDefault(
                x => x.UserId == userId &&
                     x.RoleId == roleId);
        }

        public void Add(RoleUser roleUser)
        {
            _dbSet.Add(roleUser);
        }

        public void Delete(RoleUser roleUser)
        {
            _dbSet.Remove(roleUser);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}