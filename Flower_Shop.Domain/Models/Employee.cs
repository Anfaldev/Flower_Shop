using System.Collections.Generic;
using Flower_Shop.Models;

namespace Flower_Shop.Domain.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string UID { get; set; } = Guid.NewGuid().ToString();

        public string Name { get; set; } = "";

        public string? ImageUrl { get; set; }

        public ICollection<EmployeeFile> Files { get; set; } = new List<EmployeeFile>();
    }
}