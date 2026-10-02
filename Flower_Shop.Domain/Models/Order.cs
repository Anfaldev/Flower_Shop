using System;
using Flower_Shop.Models;

namespace Flower_Shop.Domain.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string UID { get; set; } = Guid.NewGuid().ToString();

        public DateTime OrderDate { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public ICollection<OrderItem>? OrderItems { get; set; }
    }
}

