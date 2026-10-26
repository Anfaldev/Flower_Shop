using Flower_Shop.Application.Dtos.OrdersDtos;
using Flower_Shop.Domain.Models;


namespace Flower_Shop.Application.Services
{
    public interface IOrderService
    {
        IEnumerable<OrderDto> GetAllOrders();

        Order? GetOrderById(int id);

        Order? GetOrderByUid(string uid);

        void AddOrder(int userId);

        void UpdateOrder(UpdateOrderDto dto);

        void DeleteOrder(int id);
    }
}
