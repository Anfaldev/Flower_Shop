using System;
using Flower_Shop.Models;

namespace Flower_Shop.Repositories
{
    public interface IPermissionRepository
    {
        IEnumerable<Permission> GetAll();

        Permission? GetById(int id);

        Permission? GetByUId(string uid);

        void Add(Permission permission);

        void Update(Permission permission);

        void Delete(Permission permission);

        void Save();
    }
}

