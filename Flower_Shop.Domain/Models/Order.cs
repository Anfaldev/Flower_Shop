using System;
using Flower_Shop.Models;

namespace Flower_Shop.Domain.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string UID { get; set; } = Guid.NewGuid().ToString();

        public DateTime OrderDate { get; set; }

        public int UserId { get; set; }

        public User User { get; set; } = null!;

        public string Status { get; set; } = "Pending";

        public ICollection<OrderItem> OrderItems { get; set; }
        = new List<OrderItem>();
    }
}
