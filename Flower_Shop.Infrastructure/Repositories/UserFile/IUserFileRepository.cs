using Flower_Shop.Domain.Models;

namespace Flower_Shop.Infrastructure.Repositories
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

