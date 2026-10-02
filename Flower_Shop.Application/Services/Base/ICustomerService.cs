using Flower_Shop.Application.Dtos.CustomersDtos;
using Flower_Shop.Domain.Models;


namespace Flower_Shop.Application.Services
{
    public interface ICustomerService
    {
        IEnumerable<CustomerDto> GetAllCustomers();

        Customer? GetCustomerById(int id);

        Customer? GetCustomerByUid(string uid);

        void AddCustomer(CreateCustomerDto dto);

        void UpdateCustomer(UpdateCustomerDto dto);

        void DeleteCustomer(int id);
    }
}