namespace Flower_Shop.Application.Dtos.CartDtos
{
    public class CartItemDto
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public string? ImageUrl { get; set; }

        public int Quantity { get; set; }
    }
}