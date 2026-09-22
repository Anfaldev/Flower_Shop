using System;
namespace Flower_Shop.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string UID { get; set; } = Guid.NewGuid().ToString();

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public string? ImageUrl { get; set; }

        public int? CategoryId { get; set; }

        public Category? Category { get; set; }
    }
}

