using Flower_Shop.Application.Dtos.CustomersDtos;
using Flower_Shop.Domain.Models;
using Flower_Shop.Infrastructure.Repositories;


namespace Flower_Shop.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<CustomerDto> GetAllCustomers()
        {
            var customers = _unitOfWork.CustomerRepo.GetAll();

            return customers.Select(c => new CustomerDto
            {
                Id = c.Id,
                UID = c.UID,
                Name = c.Name,
                Email = c.Email,
                Phone = c.Phone
            }).ToList();
        }

        public Customer? GetCustomerById(int id)
        {
            return _unitOfWork.CustomerRepo.GetById(id);
        }

        public Customer? GetCustomerByUid(string uid)
        {
            return _unitOfWork.CustomerRepo.GetByUId(uid);
        }

        public void AddCustomer(CreateCustomerDto dto)
        {
            var customer = new Customer
            {
                Name = dto.Name,
                Email = dto.Email,
                Phone = dto.Phone
            };

            _unitOfWork.CustomerRepo.Add(customer);
            _unitOfWork.Save();
        }

        public void UpdateCustomer(UpdateCustomerDto dto)
        {
            var customer = _unitOfWork.CustomerRepo.GetById(dto.Id);

            if (customer == null)
            {
                return;
            }

            customer.Name = dto.Name;
            customer.Email = dto.Email;
            customer.Phone = dto.Phone;

            _unitOfWork.CustomerRepo.Update(customer);
            _unitOfWork.Save();
        }

        public void DeleteCustomer(int id)
        {
            var customer = _unitOfWork.CustomerRepo.GetById(id);

            if (customer == null)
            {
                return;
            }

            _unitOfWork.CustomerRepo.Delete(customer);
            _unitOfWork.Save();
        }
    }
}