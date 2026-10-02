using Flower_Shop.Models;

namespace Flower_Shop.Application.Services
{
    public interface IEmployeeFileService
    {
        IEnumerable<EmployeeFile> GetAllEmployeeFiles();

        EmployeeFile? GetEmployeeFileById(int id);

        EmployeeFile? GetEmployeeFileByUid(string uid);

        IEnumerable<EmployeeFile> GetFilesByEmployeeId(int employeeId);

        void AddEmployeeFile(EmployeeFile employeeFile);

        void UpdateEmployeeFile(EmployeeFile employeeFile);

        void DeleteEmployeeFile(int id);
    }
}