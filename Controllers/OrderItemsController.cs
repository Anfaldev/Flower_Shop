using Flower_Shop.Data;
using Flower_Shop.Dtos.OrderItemsDtos;
using Flower_Shop.Models;
using Flower_Shop.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Flower_Shop.Controllers
{
    public class OrderItemsController : Controller
    {
        private readonly IOrderItemRepository _repository;
        private readonly AppDbContext _db;

        public OrderItemsController(
            IOrderItemRepository repository,
            AppDbContext db)
        {
            _repository = repository;
            _db = db;
        }

        public IActionResult Index()
        {
            var orderItems = _repository
                .GetAll()
                .Select(o => new OrderItemDto
                {
                    Id = o.Id,
                    OrderId = o.OrderId,
                    ProductId = o.ProductId,
                    Quantity = o.Quantity,
                    ProductName = _db.Products
                        .Where(p => p.Id == o.ProductId)
                        .Select(p => p.Name)
                        .FirstOrDefault()
                })
                .ToList();

            return View(orderItems);
        }

        public IActionResult Create()
        {
            ViewBag.OrderList = new SelectList(
                _db.Orders.ToList(),
                "Id",
                "Id"
            );

            ViewBag.ProductList = new SelectList(
                _db.Products.ToList(),
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
                OrderItem orderItem = new OrderItem
                {
                    OrderId = dto.OrderId,
                    ProductId = dto.ProductId,
                    Quantity = dto.Quantity
                };

                _repository.Add(orderItem);
                _repository.Save();

                return RedirectToAction(nameof(Index));
            }

            ViewBag.OrderList = new SelectList(
                _db.Orders.ToList(),
                "Id",
                "Id"
            );

            ViewBag.ProductList = new SelectList(
                _db.Products.ToList(),
                "Id",
                "Name"
            );

            return View(dto);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var orderItem = _repository.GetById(id);

            if (orderItem == null)
            {
                return NotFound();
            }

            ViewBag.OrderList = new SelectList(
                _db.Orders.ToList(),
                "Id",
                "Id"
            );

            ViewBag.ProductList = new SelectList(
                _db.Products.ToList(),
                "Id",
                "Name"
            );

            UpdateOrderItemDto dto = new UpdateOrderItemDto
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
                var orderItem = _repository.GetById(dto.Id);

                if (orderItem == null)
                {
                    return NotFound();
                }

                orderItem.OrderId = dto.OrderId;
                orderItem.ProductId = dto.ProductId;
                orderItem.Quantity = dto.Quantity;

                _repository.Update(orderItem);
                _repository.Save();

                return RedirectToAction(nameof(Index));
            }

            ViewBag.OrderList = new SelectList(
                _db.Orders.ToList(),
                "Id",
                "Id"
            );

            ViewBag.ProductList = new SelectList(
                _db.Products.ToList(),
                "Id",
                "Name"
            );

            return View(dto);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var orderItem = _repository.GetById(id);

            if (orderItem == null)
            {
                return NotFound();
            }

            OrderItemDto dto = new OrderItemDto
            {
                Id = orderItem.Id,
                OrderId = orderItem.OrderId,
                ProductId = orderItem.ProductId,
                Quantity = orderItem.Quantity
            };

            return View(dto);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var orderItem = _repository.GetById(id);

            if (orderItem == null)
            {
                return NotFound();
            }

            _repository.Delete(orderItem);
            _repository.Save();

            return RedirectToAction(nameof(Index));
        }
    }
}