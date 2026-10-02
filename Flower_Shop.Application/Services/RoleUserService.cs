using Flower_Shop.Domain.Models;
using Flower_Shop.Infrastructure.Repositories;


namespace Flower_Shop.Application.Services
{
    public class RoleUserService : IRoleUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoleUserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<RoleUser> GetAllRoleUsers()
        {
            return _unitOfWork.RoleUserRepo.GetAll();
        }

        public IEnumerable<int> GetRoleIdsByUserId(int userId)
        {
            return _unitOfWork.RoleUserRepo
                .GetAll()
                .Where(x => x.UserId == userId)
                .Select(x => x.RoleId)
                .ToList();
        }

        public void AddRoleToUser(int userId, int roleId)
        {
            var existing =
                _unitOfWork.RoleUserRepo
                    .GetByUserIdAndRoleId(userId, roleId);

            if (existing != null)
            {
                return;
            }

            var roleUser = new RoleUser
            {
                UserId = userId,
                RoleId = roleId
            };

            _unitOfWork.RoleUserRepo.Add(roleUser);
            _unitOfWork.Save();
        }

        public void RemoveRoleFromUser(int userId, int roleId)
        {
            var roleUser =
                _unitOfWork.RoleUserRepo
                    .GetByUserIdAndRoleId(userId, roleId);

            if (roleUser == null)
            {
                return;
            }

            _unitOfWork.RoleUserRepo.Delete(roleUser);
            _unitOfWork.Save();
        }

        public void RemoveAllRolesFromUser(int userId)
        {
            var roles =
                _unitOfWork.RoleUserRepo
                    .GetAll()
                    .Where(x => x.UserId == userId)
                    .ToList();

            foreach (var role in roles)
            {
                _unitOfWork.RoleUserRepo.Delete(role);
            }

            _unitOfWork.Save();
        }
    }
}