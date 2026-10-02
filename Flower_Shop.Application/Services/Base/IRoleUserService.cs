using Flower_Shop.Domain.Models;


namespace Flower_Shop.Application.Services
{
    public interface IRoleUserService
    {
        IEnumerable<RoleUser> GetAllRoleUsers();

        IEnumerable<int> GetRoleIdsByUserId(int userId);

        void AddRoleToUser(int userId, int roleId);

        void RemoveRoleFromUser(int userId, int roleId);

        void RemoveAllRolesFromUser(int userId);
    }
}