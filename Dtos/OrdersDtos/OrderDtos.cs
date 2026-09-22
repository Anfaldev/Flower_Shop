namespace Flower_Shop.Dtos.OrdersDtos
{
    public class CreateOrderDto
    {
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
    }

    public class UpdateOrderDto : CreateOrderDto
    {
        public int Id { get; set; }
        public string UID { get; set; } = "";
    }

    public class OrderDto : UpdateOrderDto
    {
        public string? CustomerName { get; set; }
    }
}