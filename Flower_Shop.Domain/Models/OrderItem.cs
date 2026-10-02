using System;
using Flower_Shop.Domain.Models;

namespace Flower_Shop.Domain.Models
{
    public class OrderItem
    {
        public int Id { get; set; }

        public string UID { get; set; } = Guid.NewGuid().ToString();

        public int OrderId { get; set; }

        public Order Order { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }
    }
}

