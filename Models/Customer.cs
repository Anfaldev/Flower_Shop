using System;
namespace Flower_Shop.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string UID { get; set; } = Guid.NewGuid().ToString();

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
    }
}

