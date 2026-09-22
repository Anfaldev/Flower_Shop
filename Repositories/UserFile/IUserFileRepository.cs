using System;
using Flower_Shop.Models;

namespace Flower_Shop.Repositories
{
    public interface IUserFileRepository
    {
        IEnumerable<UserFile> GetAll();

        UserFile? GetById(int id);

        UserFile? GetByUId(string uid);

        void Add(UserFile userFile);

        void Update(UserFile userFile);

        void Delete(UserFile userFile);

        void Save();
    }
}

