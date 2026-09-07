
using Flower_Shop.Data;
using Flower_Shop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Flower_Shop.Controllers
{
    public class OrdersController : Controller
    {
        private readonly AppDbContext _db;

        public OrdersController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Order> orders = _db.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .ToList();

            return View(orders);
        }

        public IActionResult Create()
        {
            IEnumerable<Customer> customerList = _db.Customers.ToList();

            SelectList listItems = new SelectList(customerList, "Id", "Name");
            ViewBag.CustomerList = listItems;

            return View();
        }

        [HttpPost]
        public IActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {
                _db.Orders.Add(order);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(order);
        }

        public IActionResult Edit(int id)
        {
            var order = _db.Orders
                .Include(o => o.Customer)
                .FirstOrDefault(o => o.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            IEnumerable<Customer> customerList = _db.Customers.ToList();
            SelectList listItems = new SelectList(customerList, "Id", "Name");
            ViewBag.CustomerList = listItems;

            return View(order);
        }

        [HttpPost]
        public IActionResult Edit(Order order)
        {
            if (ModelState.IsValid)
            {
                _db.Orders.Update(order);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(order);
        }

        public IActionResult Delete(int id)
        {
            var order = _db.Orders.Find(id);

            if (order == null)
            {
                return NotFound();
            }

            _db.Orders.Remove(order);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}

