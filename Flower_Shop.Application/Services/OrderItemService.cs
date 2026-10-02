using Flower_Shop.Application.Dtos.OrderItemsDtos;
using Flower_Shop.Domain.Models;
using Flower_Shop.Infrastructure.Repositories;
using Flower_Shop.Models;


namespace Flower_Shop.Application.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderItemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<OrderItemDto> GetAllOrderItems()
        {
            var orderItems = _unitOfWork.OrderItemRepo.GetAll();

            return orderItems.Select(o => new OrderItemDto
            {
                Id = o.Id,
                OrderId = o.OrderId,
                ProductId = o.ProductId,
                Quantity = o.Quantity,

                ProductName = _unitOfWork.ProductRepo
                    .GetById(o.ProductId)?.Name

            }).ToList();
        }

        public OrderItem? GetOrderItemById(int id)
        {
            return _unitOfWork.OrderItemRepo.GetById(id);
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _unitOfWork.OrderRepo.GetAll();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _unitOfWork.ProductRepo.GetAll();
        }

        public void AddOrderItem(CreateOrderItemDto dto)
        {
            var orderItem = new OrderItem
            {
                OrderId = dto.OrderId,
                ProductId = dto.ProductId,
                Quantity = dto.Quantity
            };

            _unitOfWork.OrderItemRepo.Add(orderItem);
            _unitOfWork.Save();
        }

        public void UpdateOrderItem(UpdateOrderItemDto dto)
        {
            var orderItem = _unitOfWork.OrderItemRepo
                .GetById(dto.Id);

            if (orderItem == null)
            {
                return;
            }

            orderItem.OrderId = dto.OrderId;
            orderItem.ProductId = dto.ProductId;
            orderItem.Quantity = dto.Quantity;

            _unitOfWork.OrderItemRepo.Update(orderItem);
            _unitOfWork.Save();
        }

        public void DeleteOrderItem(int id)
        {
            var orderItem = _unitOfWork.OrderItemRepo
                .GetById(id);

            if (orderItem == null)
            {
                return;
            }

            _unitOfWork.OrderItemRepo.Delete(orderItem);
            _unitOfWork.Save();
        }
    }
}