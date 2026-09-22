using System;
using Flower_Shop.Data;
using Flower_Shop.Models;
using Microsoft.EntityFrameworkCore;

namespace Flower_Shop.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _db;
        private readonly DbSet<Employee> _dbSet;

        public EmployeeRepository(AppDbContext db)
        {
            _db = db;
            _dbSet = _db.Set<Employee>();
        }

        public void Add(Employee employee)
        {
            _dbSet.Add(employee);
        }

        public void Delete(Employee employee)
        {
            _dbSet.Remove(employee);
        }

        public IEnumerable<Employee> GetAll()
        {
            return _dbSet.ToList();
        }

        public Employee? GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public Employee? GetByUId(string uid)
        {
            return _dbSet.FirstOrDefault(e => e.UID == uid);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Employee employee)
        {
            _dbSet.Update(employee);
        }
    }
}

