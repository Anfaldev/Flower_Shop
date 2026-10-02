using System;
using Flower_Shop.Models;

namespace Flower_Shop.Domain.Models
{
    public class Permission
    {
        public int Id { get; set; }

        public string UID { get; set; } = Guid.NewGuid().ToString();

        public string Name { get; set; } = "";

        public ICollection<Role> Roles { get; set; } = new List<Role>();
    }
}
