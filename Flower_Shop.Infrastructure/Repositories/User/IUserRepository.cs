using Flower_Shop.Domain.Models;

namespace Flower_Shop.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();

        // IUserRepository.cs
        User? GetByUsername(string username);
        User? GetByEmail(string email);

        User? GetById(int id);

        User? GetByUId(string uid);

        void Add(User user);

        void Update(User user);

        void Delete(User user);

        void Save();
        
    }
}
