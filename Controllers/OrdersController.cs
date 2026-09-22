using Flower_Shop.Data;
using Flower_Shop.Dtos.OrdersDtos;
using Flower_Shop.Models;
using Flower_Shop.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Flower_Shop.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderRepository _repository;
        private readonly AppDbContext _db;

        public OrdersController(
            IOrderRepository repository,
            AppDbContext db)
        {
            _repository = repository;
            _db = db;
        }

        public IActionResult Index()
        {
            var orders = _repository
                .GetAll()
                .Select(o => new OrderDto
                {
                    Id = o.Id,
                    UID = o.UID,
                    OrderDate = o.OrderDate,
                    CustomerId = o.CustomerId,
                    CustomerName = _db.Customers
                        .Where(c => c.Id == o.CustomerId)
                        .Select(c => c.Name)
                        .FirstOrDefault()
                })
                .ToList();

            return View(orders);
        }

        public IActionResult Create()
        {
            IEnumerable<Customer> customerList =
                _db.Customers.ToList();

            ViewBag.CustomerList = new SelectList(
                customerList,
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
                Order order = new Order
                {
                    OrderDate = dto.OrderDate,
                    CustomerId = dto.CustomerId
                };

                _repository.Add(order);
                _repository.Save();

                return RedirectToAction(nameof(Index));
            }

            IEnumerable<Customer> customerList =
                _db.Customers.ToList();

            ViewBag.CustomerList = new SelectList(
                customerList,
                "Id",
                "Name"
            );

            return View(dto);
        }

        [HttpGet]
        public IActionResult Edit(string uid)
        {
            var order = _repository.GetByUId(uid);

            if (order == null)
            {
                return NotFound();
            }

            IEnumerable<Customer> customerList =
                _db.Customers.ToList();

            ViewBag.CustomerList = new SelectList(
                customerList,
                "Id",
                "Name"
            );

            UpdateOrderDto dto = new UpdateOrderDto
            {
                Id = order.Id,
                UID = order.UID,
                OrderDate = order.OrderDate,
                CustomerId = order.CustomerId
            };

            return View(dto);
        }

        [HttpPost]
        public IActionResult Edit(UpdateOrderDto dto)
        {
            if (ModelState.IsValid)
            {
                var order = _repository.GetById(dto.Id);

                if (order == null)
                {
                    return NotFound();
                }

                order.OrderDate = dto.OrderDate;
                order.CustomerId = dto.CustomerId;

                _repository.Update(order);
                _repository.Save();

                return RedirectToAction(nameof(Index));
            }

            IEnumerable<Customer> customerList =
                _db.Customers.ToList();

            ViewBag.CustomerList = new SelectList(
                customerList,
                "Id",
                "Name"
            );

            return View(dto);
        }

        [HttpGet]
        public IActionResult Delete(string uid)
        {
            var order = _repository.GetByUId(uid);

            if (order == null)
            {
                return NotFound();
            }

            _repository.Delete(order);
            _repository.Save();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(string uid)
        {
            var order = _db.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                .FirstOrDefault(o => o.UID == uid);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }
    }
}