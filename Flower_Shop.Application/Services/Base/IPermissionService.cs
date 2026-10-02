using Flower_Shop.Domain.Models;


namespace Flower_Shop.Application.Services
{
    public interface IPermissionService
    {
        IEnumerable<Permission> GetAllPermissions();
        Permission? GetPermissionById(int id);
        Permission? GetPermissionByUid(string uid);
        void AddPermission(Permission permission);
        void UpdatePermission(Permission permission);
        void DeletePermission(int id);
    }
}