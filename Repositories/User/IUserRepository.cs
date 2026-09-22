using System;
using Flower_Shop.Models;

namespace Flower_Shop.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();

        User? GetById(int id);

        User? GetByUId(string uid);

        void Add(User user);

        void Update(User user);

        void Delete(User user);

        void Save();
    }
}
