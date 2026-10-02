using Flower_Shop.Domain.Models;
using Flower_Shop.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Flower_Shop.Infrastructure.Repositories
{
    public class PermissionRoleRepository : IPermissionRoleRepository
    {
        private readonly AppDbContext _db;
        private readonly DbSet<PermissionRole> _dbSet;

        public PermissionRoleRepository(AppDbContext db)
        {
            _db = db;
            _dbSet = _db.Set<PermissionRole>();
        }

        public IEnumerable<PermissionRole> GetAll()
        {
            return _dbSet.ToList();
        }

        public PermissionRole? GetByPermissionIdAndRoleId(
            int permissionId,
            int roleId)
        {
            return _dbSet.FirstOrDefault(
                x => x.PermissionId == permissionId &&
                     x.RoleId == roleId);
        }

        public void Add(PermissionRole permissionRole)
        {
            _dbSet.Add(permissionRole);
        }

        public void Delete(PermissionRole permissionRole)
        {
            _dbSet.Remove(permissionRole);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}