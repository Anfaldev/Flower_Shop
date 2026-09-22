using System;
using Flower_Shop.Data;
using Flower_Shop.Models;
using Microsoft.EntityFrameworkCore;

namespace Flower_Shop.Repositories
{
    public class EmployeeFileRepository : IEmployeeFileRepository
    {
        private readonly AppDbContext _db;
        private readonly DbSet<EmployeeFile> _dbSet;

        public EmployeeFileRepository(AppDbContext db)
        {
            _db = db;
            _dbSet = _db.Set<EmployeeFile>();
        }

        public void Add(EmployeeFile employeeFile)
        {
            _dbSet.Add(employeeFile);
        }

        public void Delete(EmployeeFile employeeFile)
        {
            _dbSet.Remove(employeeFile);
        }

        public IEnumerable<EmployeeFile> GetAll()
        {
            return _dbSet.ToList();
        }

        public EmployeeFile? GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public EmployeeFile? GetByUId(string uid)
        {
            return _dbSet.FirstOrDefault(e => e.UID == uid);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(EmployeeFile employeeFile)
        {
            _dbSet.Update(employeeFile);
        }
    }
}
