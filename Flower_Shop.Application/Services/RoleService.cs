using Flower_Shop.Domain.Models;
using Flower_Shop.Infrastructure.Repositories;


namespace Flower_Shop.Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Role> GetAllRoles()
        {
            return _unitOfWork.RoleRepo.GetAll();
        }

        public Role? GetRoleById(int id)
        {
            return _unitOfWork.RoleRepo.GetById(id);
        }

        public Role? GetRoleByUid(string uid)
        {
            return _unitOfWork.RoleRepo.GetByUId(uid);
        }

        public void AddRole(Role role)
        {
            _unitOfWork.RoleRepo.Add(role);
            _unitOfWork.Save();
        }

        public void UpdateRole(Role role)
        {
            var existingRole =
                _unitOfWork.RoleRepo.GetById(role.Id);

            if (existingRole == null)
            {
                return;
            }

            existingRole.Name = role.Name;

            _unitOfWork.RoleRepo.Update(existingRole);
            _unitOfWork.Save();
        }

        public void DeleteRole(int id)
        {
            var role =
                _unitOfWork.RoleRepo.GetById(id);

            if (role == null)
            {
                return;
            }

            _unitOfWork.RoleRepo.Delete(role);
            _unitOfWork.Save();
        }
    }
}