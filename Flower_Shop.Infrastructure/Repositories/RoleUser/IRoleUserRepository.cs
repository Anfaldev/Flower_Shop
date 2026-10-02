using Flower_Shop.Domain.Models;


namespace Flower_Shop.Infrastructure.Repositories
{
    public interface IRoleUserRepository
    {
        IEnumerable<RoleUser> GetAll();

        RoleUser? GetByUserIdAndRoleId(int userId, int roleId);

        void Add(RoleUser roleUser);

        void Delete(RoleUser roleUser);

        void Save();
    }
}