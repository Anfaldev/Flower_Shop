using System;
namespace Flower_Shop.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string UID { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}

