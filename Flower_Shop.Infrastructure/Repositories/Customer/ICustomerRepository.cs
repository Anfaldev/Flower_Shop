using Flower_Shop.Domain.Models;

namespace Flower_Shop.Infrastructure.Repositories
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAll();

        Customer? GetById(int id);

        Customer? GetByUId(string uid);

        void Add(Customer customer);

        void Update(Customer customer);

        void Delete(Customer customer);

        void Save();
    }
}