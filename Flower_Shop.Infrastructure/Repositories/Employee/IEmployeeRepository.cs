using System;
using Flower_Shop.Domain.Models;
using Flower_Shop.Models;

namespace Flower_Shop.Infrastructure.Repositories
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();

        Employee? GetById(int id);

        Employee? GetByUId(string uid);

        void Add(Employee employee);

        void Update(Employee employee);

        void Delete(Employee employee);

        void Save();
    }
}

