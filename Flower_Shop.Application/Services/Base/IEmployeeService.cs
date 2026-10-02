using Flower_Shop.Domain.Models;
using Flower_Shop.Models;

namespace Flower_Shop.Application.Services
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAllEmployees();

        Employee? GetEmployeeById(int id);

        Employee? GetEmployeeByUid(string uid);

        void AddEmployee(Employee employee);

        void UpdateEmployee(Employee employee);

        void DeleteEmployee(int id);
    }
}