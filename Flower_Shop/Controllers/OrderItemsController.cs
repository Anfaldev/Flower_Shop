using Flower_Shop.Application.Dtos.OrderItemsDtos;
using Flower_Shop.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Flower_Shop.Controllers
{
    public class OrderItemsController : Controller
    {
        private readonly IOrderItemService _orderItemService;

        public OrderItemsController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        public IActionResult Index()
        {
            var orderItems = _orderItemService.GetAllOrderItems();

            return View(orderItems);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.OrderList = new SelectList(
                _orderItemService.GetAllOrders(),
                "Id",
                "Id"
            );

            ViewBag.ProductList = new SelectList(
                _orderItemService.GetAllProducts(),
                "Id",
                "Name"
            );

            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateOrderItemDto dto)
        {
            if (ModelState.IsValid)
            {
                _orderItemService.AddOrderItem(dto);

                return RedirectToAction(nameof(Index));
            }

            ViewBag.OrderList = new SelectList(
                _orderItemService.GetAllOrders(),
                "Id",
                "Id",
                dto.OrderId
            );

            ViewBag.ProductList = new SelectList(
                _orderItemService.GetAllProducts(),
                "Id",
                "Name",
                dto.ProductId
            );

            return View(dto);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var orderItem = _orderItemService
                .GetOrderItemById(id);

            if (orderItem == null)
            {
                return NotFound();
            }

            ViewBag.OrderList = new SelectList(
                _orderItemService.GetAllOrders(),
                "Id",
                "Id",
                orderItem.OrderId
            );

            ViewBag.ProductList = new SelectList(
                _orderItemService.GetAllProducts(),
                "Id",
                "Name",
                orderItem.ProductId
            );

            var dto = new UpdateOrderItemDto
            {
                Id = orderItem.Id,
                OrderId = orderItem.OrderId,
                ProductId = orderItem.ProductId,
                Quantity = orderItem.Quantity
            };

            return View(dto);
        }

        [HttpPost]
        public IActionResult Edit(UpdateOrderItemDto dto)
        {
            if (ModelState.IsValid)
            {
                var orderItem = _orderItemService
                    .GetOrderItemById(dto.Id);

                if (orderItem == null)
                {
                    return NotFound();
                }

                _orderItemService.UpdateOrderItem(dto);

                return RedirectToAction(nameof(Index));
            }

            ViewBag.OrderList = new SelectList(
                _orderItemService.GetAllOrders(),
                "Id",
                "Id",
                dto.OrderId
            );

            ViewBag.ProductList = new SelectList(
                _orderItemService.GetAllProducts(),
                "Id",
                "Name",
                dto.ProductId
            );

            return View(dto);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var orderItem = _orderItemService
                .GetOrderItemById(id);

            if (orderItem == null)
            {
                return NotFound();
            }

            var dto = new OrderItemDto
            {
                Id = orderItem.Id,
                OrderId = orderItem.OrderId,
                ProductId = orderItem.ProductId,
                Quantity = orderItem.Quantity,

                ProductName = _orderItemService
                    .GetAllProducts()
                    .FirstOrDefault(p => p.Id == orderItem.ProductId)
                    ?.Name
            };

            return View(dto);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var orderItem = _orderItemService
                .GetOrderItemById(id);

            if (orderItem == null)
            {
                return NotFound();
            }

            _orderItemService.DeleteOrderItem(id);

            return RedirectToAction(nameof(Index));
        }
    }
}