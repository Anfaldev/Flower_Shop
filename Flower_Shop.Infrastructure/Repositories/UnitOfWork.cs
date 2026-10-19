using Flower_Shop.Infrastructure.Data;

namespace Flower_Shop.Infrastructure.Repositories.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _db;

        public UnitOfWork(AppDbContext db)
        {
            _db = db;

            CategoryRepo = new CategoryRepository(db);
            ProductRepo = new ProductRepository(db);
            CustomerRepo = new CustomerRepository(db);
            OrderRepo = new OrderRepository(db);
            OrderItemRepo = new OrderItemRepository(db);
            UserRepo = new UserRepository(db);
            UserFileRepo = new UserFileRepository(db);
            RoleRepo = new RoleRepository(db);
            PermissionRepo = new PermissionRepository(db);
            EmployeeRepo = new EmployeeRepository(db);
            EmployeeFileRepo = new EmployeeFileRepository(db);
            CartRepo = new CartRepository(db);
        }

        public ICategoryRepository CategoryRepo { get; }
        public IProductRepository ProductRepo { get; }
        public ICustomerRepository CustomerRepo { get; }
        public IOrderRepository OrderRepo { get; }
        public IOrderItemRepository OrderItemRepo { get; }
        public IUserRepository UserRepo { get; }
        public IUserFileRepository UserFileRepo { get; }
        public IRoleRepository RoleRepo { get; }
        public IPermissionRepository PermissionRepo { get; }
        public IEmployeeRepository EmployeeRepo { get; }
        public IEmployeeFileRepository EmployeeFileRepo { get; }

        public ICartRepository CartRepo { get; }

        public IRoleUserRepository RoleUserRepo =>
            throw new NotImplementedException();

        public IPermissionRoleRepository PermissionRoleRepo =>
            throw new NotImplementedException();

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}