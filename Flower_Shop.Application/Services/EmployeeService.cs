using Flower_Shop.Domain.Models;
using Flower_Shop.Infrastructure.Repositories;


namespace Flower_Shop.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _unitOfWork.EmployeeRepo.GetAll();
        }

        public Employee? GetEmployeeById(int id)
        {
            return _unitOfWork.EmployeeRepo.GetById(id);
        }

        public Employee? GetEmployeeByUid(string uid)
        {
            return _unitOfWork.EmployeeRepo.GetByUId(uid);
        }

        public void AddEmployee(Employee employee)
        {
            _unitOfWork.EmployeeRepo.Add(employee);
            _unitOfWork.Save();
        }

        public void UpdateEmployee(Employee employee)
        {
            var existingEmployee = _unitOfWork.EmployeeRepo
                .GetById(employee.Id);

            if (existingEmployee == null)
            {
                return;
            }

            existingEmployee.Name = employee.Name;
            existingEmployee.ImageUrl = employee.ImageUrl;

            _unitOfWork.EmployeeRepo.Update(existingEmployee);
            _unitOfWork.Save();
        }

        public void DeleteEmployee(int id)
        {
            var employee = _unitOfWork.EmployeeRepo.GetById(id);

            if (employee == null)
            {
                return;
            }

            _unitOfWork.EmployeeRepo.Delete(employee);
            _unitOfWork.Save();
        }
    }
}