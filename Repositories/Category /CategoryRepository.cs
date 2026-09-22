using Flower_Shop.Data;
using Flower_Shop.Models;
using Microsoft.EntityFrameworkCore;

namespace Flower_Shop.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _db;
        private readonly DbSet<Category> _dbSet;

        public CategoryRepository(AppDbContext db)
        {
            _db = db;
            _dbSet = _db.Set<Category>();
        }

        public void Add(Category category)
        {
            _dbSet.Add(category);
        }

        public void Delete(Category category)
        {
            _dbSet.Remove(category);
        }

        public IEnumerable<Category> GetAll()
        {
            return _dbSet.ToList();
        }

        public Category? GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public Category? GetByUId(string uid)
        {
            return _dbSet.FirstOrDefault(e => e.UID == uid);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Category category)
        {
            _dbSet.Update(category);
        }
    }
}