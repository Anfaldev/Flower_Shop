using Microsoft.AspNetCore.Mvc;
using Flower_Shop.Models;
using Flower_Shop.Dtos.CustomersDtos;
using Flower_Shop.Repositories;

namespace Flower_Shop.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerRepository _repository;

        public CustomersController(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var customers = _repository
                .GetAll()
                .Select(c => new CustomerDto
                {
                    Id = c.Id,
                    UID = c.UID,
                    Name = c.Name,
                    Email = c.Email,
                    Phone = c.Phone
                })
                .ToList();

            return View(customers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateCustomerDto dto)
        {
            if (ModelState.IsValid)
            {
                Customer customer = new Customer
                {
                    Name = dto.Name,
                    Email = dto.Email,
                    Phone = dto.Phone
                };

                _repository.Add(customer);
                _repository.Save();

                return RedirectToAction(nameof(Index));
            }

            return View(dto);
        }

        [HttpGet]
        public IActionResult Edit(string uid)
        {
            var customer = _repository.GetByUId(uid);

            if (customer == null)
            {
                return NotFound();
            }

            UpdateCustomerDto dto = new UpdateCustomerDto
            {
                Id = customer.Id,
                UID = customer.UID,
                Name = customer.Name,
                Email = customer.Email,
                Phone = customer.Phone
            };

            return View(dto);
        }

        [HttpPost]
        public IActionResult Edit(UpdateCustomerDto dto)
        {
            if (ModelState.IsValid)
            {
                var customer = _repository.GetById(dto.Id);

                if (customer == null)
                {
                    return NotFound();
                }

                customer.Name = dto.Name;
                customer.Email = dto.Email;
                customer.Phone = dto.Phone;

                _repository.Update(customer);
                _repository.Save();

                return RedirectToAction(nameof(Index));
            }

            return View(dto);
        }

        [HttpGet]
        public IActionResult Delete(string uid)
        {
            var customer = _repository.GetByUId(uid);

            if (customer == null)
            {
                return NotFound();
            }

            CustomerDto dto = new CustomerDto
            {
                Id = customer.Id,
                UID = customer.UID,
                Name = customer.Name,
                Email = customer.Email,
                Phone = customer.Phone
            };

            return View(dto);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var customer = _repository.GetById(id);

            if (customer == null)
            {
                return NotFound();
            }

            _repository.Delete(customer);
            _repository.Save();

            return RedirectToAction(nameof(Index));
        }
    }
}