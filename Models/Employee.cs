using System.Collections.Generic;

namespace Flower_Shop.Models
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