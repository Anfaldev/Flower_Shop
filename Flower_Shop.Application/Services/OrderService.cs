using Flower_Shop.Application.Dtos.OrdersDtos;
using Flower_Shop.Domain.Models;
using Flower_Shop.Infrastructure.Repositories;


namespace Flower_Shop.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<OrderDto> GetAllOrders()
        {
            var orders = _unitOfWork.OrderRepo.GetAll();

            return orders.Select(o => new OrderDto
            {
                Id = o.Id,
                UID = o.UID,
                OrderDate = o.OrderDate,
                CustomerId = o.CustomerId,
                CustomerName = _unitOfWork.CustomerRepo
                    .GetById(o.CustomerId)?.Name
            }).ToList();
        }

        public Order? GetOrderById(int id)
        {
            return _unitOfWork.OrderRepo.GetById(id);
        }

        public Order? GetOrderByUid(string uid)
        {
            return _unitOfWork.OrderRepo.GetByUId(uid);
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _unitOfWork.CustomerRepo.GetAll();
        }

        public void AddOrder(CreateOrderDto dto)
        {
            var order = new Order
            {
                OrderDate = dto.OrderDate,
                CustomerId = dto.CustomerId
            };

            _unitOfWork.OrderRepo.Add(order);
            _unitOfWork.Save();
        }

        public void UpdateOrder(UpdateOrderDto dto)
        {
            var order = _unitOfWork.OrderRepo.GetById(dto.Id);

            if (order == null)
            {
                return;
            }

            order.OrderDate = dto.OrderDate;
            order.CustomerId = dto.CustomerId;

            _unitOfWork.OrderRepo.Update(order);
            _unitOfWork.Save();
        }

        public void DeleteOrder(int id)
        {
            var order = _unitOfWork.OrderRepo.GetById(id);

            if (order == null)
            {
                return;
            }

            _unitOfWork.OrderRepo.Delete(order);
            _unitOfWork.Save();
        }
    }
}