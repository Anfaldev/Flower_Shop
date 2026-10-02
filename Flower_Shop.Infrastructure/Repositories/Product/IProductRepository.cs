using Flower_Shop.Domain.Models;


namespace Flower_Shop.Infrastructure.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();

        Product? GetById(int id);

        Product? GetByUId(string uid);

        void Add(Product product);

        void Update(Product product);

        void Delete(Product product);

        void Save();
    }
}

