using System;
using Flower_Shop.Models;

namespace Flower_Shop.Repositories
{
    public interface IEmployeeFileRepository
    {
        IEnumerable<EmployeeFile> GetAll();

        EmployeeFile? GetById(int id);

        EmployeeFile? GetByUId(string uid);

        void Add(EmployeeFile employeeFile);

        void Update(EmployeeFile employeeFile);

        void Delete(EmployeeFile employeeFile);

        void Save();
    }
}

