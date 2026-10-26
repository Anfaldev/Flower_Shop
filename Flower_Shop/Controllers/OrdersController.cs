using Flower_Shop.Application.Dtos.OrdersDtos;
using Flower_Shop.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Flower_Shop.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public IActionResult Index()
        {
            var orders = _orderService.GetAllOrders();
            return View(orders);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateOrderDto dto)
        {
            var userIdClaim = User.FindFirstValue("UserId");

            if (string.IsNullOrEmpty(userIdClaim))
                return Challenge();

            if (ModelState.IsValid)
            {
                if (!int.TryParse(userIdClaim, out var userId))
                    return Challenge();

                _orderService.AddOrder(userId);

                return RedirectToAction(nameof(Index));
            }

            return View(dto);
        }

        [HttpGet]
        public IActionResult Edit(string uid)
        {
            var order = _orderService.GetOrderByUid(uid);

            if (order == null)
                return NotFound();

            var dto = new UpdateOrderDto
            {
                Id = order.Id,
                UID = order.UID,
                OrderDate = order.OrderDate,
                Status = order.Status
            };

            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UpdateOrderDto dto)
        {
            if (ModelState.IsValid)
            {
                var order = _orderService.GetOrderById(dto.Id);

                if (order == null)
                    return NotFound();

                _orderService.UpdateOrder(dto);

                return RedirectToAction(nameof(Index));
            }

            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateStatus(int orderId, string status)
        {
            var order = _orderService.GetOrderById(orderId);

            if (order == null)
                return NotFound();

            var allowedStatuses = new[]
            {
                "Pending",
                "Processing",
                "Completed",
                "Cancelled"
            };

            if (string.IsNullOrWhiteSpace(status) ||
                !allowedStatuses.Contains(status))
            {
                return BadRequest("Invalid order status.");
            }

            var dto = new UpdateOrderDto
            {
                Id = order.Id,
                UID = order.UID,
                OrderDate = order.OrderDate,
                Status = status
            };

            _orderService.UpdateOrder(dto);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(string uid)
        {
            var order = _orderService.GetOrderByUid(uid);

            if (order == null)
                return NotFound();

            return View(order);
        }

        [HttpGet]
        public IActionResult Delete(string uid)
        {
            var order = _orderService.GetOrderByUid(uid);

            if (order == null)
                return NotFound();

            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var order = _orderService.GetOrderById(id);

            if (order == null)
                return NotFound();

            _orderService.DeleteOrder(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
