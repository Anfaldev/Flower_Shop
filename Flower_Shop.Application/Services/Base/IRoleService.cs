using Flower_Shop.Domain.Models;


namespace Flower_Shop.Application.Services
{
    public interface IRoleService
    {
        IEnumerable<Role> GetAllRoles();
        Role? GetRoleById(int id);
        Role? GetRoleByUid(string uid);
        void AddRole(Role role);
        void UpdateRole(Role role);
        void DeleteRole(int id);
    }
}