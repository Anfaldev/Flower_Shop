using Flower_Shop.Domain.Models;


namespace Flower_Shop.Application.Services
{
    public interface IPermissionRoleService
    {
        IEnumerable<PermissionRole> GetAllPermissionRoles();

        IEnumerable<int> GetPermissionIdsByRoleId(int roleId);

        void AddPermissionToRole(int permissionId, int roleId);

        void RemovePermissionFromRole(
            int permissionId,
            int roleId);

        void RemoveAllPermissionsFromRole(int roleId);
    }
}