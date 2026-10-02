using Flower_Shop.Infrastructure.Data;


namespace Flower_Shop.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _db;

        public IProductRepository ProductRepo { get; }
        public ICategoryRepository CategoryRepo { get; }

        public IUserRepository UserRepo { get; }
        public IUserFileRepository UserFileRepo { get; }

        public ICustomerRepository CustomerRepo { get; }

        public IOrderRepository OrderRepo { get; }
        public IOrderItemRepository OrderItemRepo { get; }

        public IEmployeeRepository EmployeeRepo { get; }
        public IEmployeeFileRepository EmployeeFileRepo { get; }

        public IRoleRepository RoleRepo { get; }
        public IRoleUserRepository RoleUserRepo { get; }

        public IPermissionRepository PermissionRepo { get; }
        public IPermissionRoleRepository PermissionRoleRepo { get; }


        public UnitOfWork(
            AppDbContext db,
            IProductRepository productRepository,
            ICategoryRepository categoryRepository,
            IUserRepository userRepository,
            IUserFileRepository userFileRepository,
            ICustomerRepository customerRepository,
            IOrderRepository orderRepository,
            IOrderItemRepository orderItemRepository,
            IEmployeeRepository employeeRepository,
            IRoleRepository roleRepository,
            IRoleUserRepository roleUserRepository,
            IPermissionRepository permissionRepository,
            IPermissionRoleRepository permissionRoleRepository,
            IEmployeeFileRepository employeeFileRepository)
        {
            _db = db;

            ProductRepo = productRepository;
            CategoryRepo = categoryRepository;
            UserRepo = userRepository;
            UserFileRepo = userFileRepository;

            CustomerRepo = customerRepository;

            OrderRepo = orderRepository;
            OrderItemRepo = orderItemRepository;

            EmployeeRepo = employeeRepository;
            EmployeeFileRepo = employeeFileRepository;

            RoleRepo = roleRepository;
            RoleUserRepo = roleUserRepository;

            PermissionRepo = permissionRepository;
            PermissionRoleRepo = permissionRoleRepository;
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}