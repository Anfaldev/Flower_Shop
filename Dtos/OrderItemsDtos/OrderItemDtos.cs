namespace Flower_Shop.Dtos.OrderItemsDtos
{
    public class CreateOrderItemDto
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }

    public class UpdateOrderItemDto : CreateOrderItemDto
    {
        public int Id { get; set; }
    }

    public class OrderItemDto : UpdateOrderItemDto
    {
        public string? ProductName { get; set; }
    }
}