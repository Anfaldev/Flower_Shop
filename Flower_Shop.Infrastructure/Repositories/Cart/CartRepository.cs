using Flower_Shop.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Flower_Shop.Domain.Models;

namespace Flower_Shop.Infrastructure.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly AppDbContext _db;
        private readonly DbSet<CartItem> _dbSet;

        public CartRepository(AppDbContext db)
        {
            _db = db;
            _dbSet = _db.Set<CartItem>();
        }

        public IEnumerable<CartItem> GetByUserId(int userId)
        {
            return _dbSet
                .Include(x => x.Product)
                .Where(x => x.UserId == userId)
                .ToList();
        }

        public CartItem? GetByUserAndProduct(int userId, int productId)
        {
            return _dbSet.FirstOrDefault(x =>
                x.UserId == userId &&
                x.ProductId == productId);
        }

        public void Add(CartItem item)
        {
            _dbSet.Add(item);
        }

        public void Delete(CartItem item)
        {
            _dbSet.Remove(item);
        }
    }
}