namespace Flower_Shop.Application.Dtos.OrdersDtos
{
    public class CreateOrderDto
    {
        public DateTime OrderDate { get; set; }
    }

    public class UpdateOrderDto : CreateOrderDto
    {
        public int Id { get; set; }
        public string UID { get; set; } = "";
        public string Status { get; set; } = "Pending";
        public int UserId { get; set; }
        public decimal TotalAmount { get; set; }
    }

    public class OrderDto : UpdateOrderDto
    {
    }
}
