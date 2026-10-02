using Flower_Shop.Domain.Models;
using Flower_Shop.Infrastructure.Repositories;

namespace Flower_Shop.Application.Services
{
    public class PermissionRoleService : IPermissionRoleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PermissionRoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<PermissionRole> GetAllPermissionRoles()
        {
            return _unitOfWork.PermissionRoleRepo.GetAll();
        }

        public IEnumerable<int> GetPermissionIdsByRoleId(int roleId)
        {
            return _unitOfWork.PermissionRoleRepo
                .GetAll()
                .Where(x => x.RoleId == roleId)
                .Select(x => x.PermissionId)
                .ToList();
        }

        public void AddPermissionToRole(
            int permissionId,
            int roleId)
        {
            var existing =
                _unitOfWork.PermissionRoleRepo
                    .GetByPermissionIdAndRoleId(
                        permissionId,
                        roleId);

            if (existing != null)
            {
                return;
            }

            var permissionRole = new PermissionRole
            {
                PermissionId = permissionId,
                RoleId = roleId
            };

            _unitOfWork.PermissionRoleRepo.Add(permissionRole);
            _unitOfWork.Save();
        }

        public void RemovePermissionFromRole(
            int permissionId,
            int roleId)
        {
            var permissionRole =
                _unitOfWork.PermissionRoleRepo
                    .GetByPermissionIdAndRoleId(
                        permissionId,
                        roleId);

            if (permissionRole == null)
            {
                return;
            }

            _unitOfWork.PermissionRoleRepo.Delete(permissionRole);
            _unitOfWork.Save();
        }

        public void RemoveAllPermissionsFromRole(int roleId)
        {
            var permissions =
                _unitOfWork.PermissionRoleRepo
                    .GetAll()
                    .Where(x => x.RoleId == roleId)
                    .ToList();

            foreach (var permission in permissions)
            {
                _unitOfWork.PermissionRoleRepo.Delete(permission);
            }

            _unitOfWork.Save();
        }
    }
}