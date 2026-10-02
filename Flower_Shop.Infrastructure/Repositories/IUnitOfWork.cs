

namespace Flower_Shop.Infrastructure.Repositories
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepo { get; }

        ICategoryRepository CategoryRepo { get; }

        IUserRepository UserRepo { get; }
        IUserFileRepository UserFileRepo { get; }

        ICustomerRepository CustomerRepo { get; }

        IOrderRepository OrderRepo { get; }
        IOrderItemRepository OrderItemRepo { get; }

        IEmployeeRepository EmployeeRepo { get; }
        IEmployeeFileRepository EmployeeFileRepo { get; }

        IRoleRepository RoleRepo { get; }
        IRoleUserRepository RoleUserRepo { get; }

        IPermissionRepository PermissionRepo { get; }
        IPermissionRoleRepository PermissionRoleRepo { get; }

        void Save();
    }
}