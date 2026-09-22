using System;
using Flower_Shop.Models;

namespace Flower_Shop.Repositories
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

