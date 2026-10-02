using Flower_Shop.Domain.Models;
using Flower_Shop.Models;

namespace Flower_Shop.Infrastructure.Repositories
{
    public interface IPermissionRoleRepository
    {
        IEnumerable<PermissionRole> GetAll();

        PermissionRole? GetByPermissionIdAndRoleId(
            int permissionId,
            int roleId);

        void Add(PermissionRole permissionRole);

        void Delete(PermissionRole permissionRole);

        void Save();
    }
}