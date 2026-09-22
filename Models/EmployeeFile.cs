using System;
using Flower_Shop.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flower_Shop.Models
{
    public class EmployeeFile
{
    public int Id { get; set; }

    public string UID { get; set; } = Guid.NewGuid().ToString();

    public string Name { get; set; } = "";

    public string FileURL { get; set; } = "";

    [ForeignKey(nameof(Employee))]
    public int EmployeeID { get; set; }

    public Employee? Employee { get; set; }
}
}