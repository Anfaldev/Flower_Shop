using Flower_Shop.Data;
using Flower_Shop.Models;
using Microsoft.EntityFrameworkCore;

namespace Flower_Shop.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _db;
        private readonly DbSet<Customer> _dbSet;

        public CustomerRepository(AppDbContext db)
        {
            _db = db;
            _dbSet = _db.Set<Customer>();
        }

        public void Add(Customer customer)
        {
            _dbSet.Add(customer);
        }

        public void Delete(Customer customer)
        {
            _dbSet.Remove(customer);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _dbSet.ToList();
        }

        public Customer? GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public Customer? GetByUId(string uid)
        {
            return _dbSet.FirstOrDefault(e => e.UID == uid);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Customer customer)
        {
            _dbSet.Update(customer);
        }
    }
}