using Flower_Shop.Models;

namespace Flower_Shop.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();

        Category? GetById(int id);

        Category? GetByUId(string uid);

        void Add(Category category);

        void Update(Category category);

        void Delete(Category category);

        void Save();
    }
}