using Flower_Shop.Domain.Models;

namespace Flower_Shop.Infrastructure.Repositories
{
    public interface IRoleRepository
    {
        IEnumerable<Role> GetAll();

        Role? GetById(int id);

        Role? GetByUId(string uid);

        void Add(Role role);

        void Update(Role role);

        void Delete(Role role);

        void Save();
    }
}

