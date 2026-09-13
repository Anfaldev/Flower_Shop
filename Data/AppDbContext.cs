using Microsoft.EntityFrameworkCore;
using Flower_Shop.Models;

namespace Flower_Shop.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }


        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RoleUser> RoleUsers { get; set; }
        public DbSet<PermissionRole> PermissionRoles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PermissionRole>()
                .HasKey(pr => new
                {
                    pr.RoleId,
                    pr.PermissionId
                });


            modelBuilder.Entity<RoleUser>()
                .HasKey(ru => new
                {
                    ru.RoleId,
                    ru.UserId
                });
        }
    }
}

