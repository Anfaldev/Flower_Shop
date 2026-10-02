using Flower_Shop.Application.Dtos.OrderItemsDtos;
using Flower_Shop.Domain.Models;
using Flower_Shop.Models;

namespace Flower_Shop.Application.Services
{
    public interface IOrderItemService
    {
        IEnumerable<OrderItemDto> GetAllOrderItems();

        OrderItem? GetOrderItemById(int id);

        IEnumerable<Order> GetAllOrders();

        IEnumerable<Product> GetAllProducts();

        void AddOrderItem(CreateOrderItemDto dto);

        void UpdateOrderItem(UpdateOrderItemDto dto);

        void DeleteOrderItem(int id);
    }
}