using Flower_Shop.Application.Dtos.OrdersDtos;
using Flower_Shop.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            ViewBag.CustomerList = new SelectList(
                _orderService.GetAllCustomers(),
                "Id",
                "Name"
            );

            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateOrderDto dto)
        {
            if (ModelState.IsValid)
            {
                _orderService.AddOrder(dto);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.CustomerList = new SelectList(
                _orderService.GetAllCustomers(),
                "Id",
                "Name",
                dto.CustomerId
            );

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
                CustomerId = order.CustomerId
            };

            ViewBag.CustomerList = new SelectList(
                _orderService.GetAllCustomers(),
                "Id",
                "Name",
                dto.CustomerId
            );

            return View(dto);
        }

        [HttpPost]
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

            ViewBag.CustomerList = new SelectList(
                _orderService.GetAllCustomers(),
                "Id",
                "Name",
                dto.CustomerId
            );

            return View(dto);
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