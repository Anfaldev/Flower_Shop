using System;
using Flower_Shop.Models;

namespace Flower_Shop.Repositories
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

