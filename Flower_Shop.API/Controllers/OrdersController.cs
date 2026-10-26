using Flower_Shop.Application.Dtos.OrdersDtos;
using Flower_Shop.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Flower_Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("{userId:int}")]
        public IActionResult CreateOrder(int userId)
        {
            _orderService.AddOrder(userId);

            return Ok(new
            {
                message = "Order created successfully"
            });
        }

        [HttpGet("user/{userId:int}")]
        public IActionResult GetOrdersByUser(int userId)
        {
            var orders = _orderService.GetAllOrders()
                .Where(o => o.UserId == userId);

            return Ok(orders);
        }
    }
}
