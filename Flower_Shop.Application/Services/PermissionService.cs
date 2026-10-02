using Flower_Shop.Domain.Models;
using Flower_Shop.Infrastructure.Repositories;


namespace Flower_Shop.Application.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PermissionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Permission> GetAllPermissions()
        {
            return _unitOfWork.PermissionRepo.GetAll();
        }

        public Permission? GetPermissionById(int id)
        {
            return _unitOfWork.PermissionRepo.GetById(id);
        }

        public Permission? GetPermissionByUid(string uid)
        {
            return _unitOfWork.PermissionRepo.GetByUId(uid);
        }

        public void AddPermission(Permission permission)
        {
            _unitOfWork.PermissionRepo.Add(permission);
            _unitOfWork.Save();
        }

        public void UpdatePermission(Permission permission)
        {
            var existingPermission =
                _unitOfWork.PermissionRepo.GetById(permission.Id);

            if (existingPermission == null)
            {
                return;
            }

            existingPermission.Name = permission.Name;

            _unitOfWork.PermissionRepo.Update(existingPermission);
            _unitOfWork.Save();
        }

        public void DeletePermission(int id)
        {
            var permission =
                _unitOfWork.PermissionRepo.GetById(id);

            if (permission == null)
            {
                return;
            }

            _unitOfWork.PermissionRepo.Delete(permission);
            _unitOfWork.Save();
        }
    }
}