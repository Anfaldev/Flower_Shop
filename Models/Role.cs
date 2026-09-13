using System;
namespace Flower_Shop.Models
{
    public class Role
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public ICollection<Permission> Permissions { get; set; } = new List<Permission>();

        public ICollection<User> Users { get; set; } = new List<User>();
    }
}