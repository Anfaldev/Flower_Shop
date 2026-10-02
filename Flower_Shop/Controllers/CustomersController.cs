using Flower_Shop.Application.Dtos.CustomersDtos;
using Flower_Shop.Application.Services;

using Microsoft.AspNetCore.Mvc;

namespace Flower_Shop.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public IActionResult Index()
        {
            var customers = _customerService.GetAllCustomers();

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
                _customerService.AddCustomer(dto);

                return RedirectToAction(nameof(Index));
            }

            return View(dto);
        }

        [HttpGet]
        public IActionResult Edit(string uid)
        {
            var customer = _customerService.GetCustomerByUid(uid);

            if (customer == null)
            {
                return NotFound();
            }

            var dto = new UpdateCustomerDto
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
                var customer = _customerService.GetCustomerById(dto.Id);

                if (customer == null)
                {
                    return NotFound();
                }

                _customerService.UpdateCustomer(dto);

                return RedirectToAction(nameof(Index));
            }

            return View(dto);
        }

        [HttpGet]
        public IActionResult Delete(string uid)
        {
            var customer = _customerService.GetCustomerByUid(uid);

            if (customer == null)
            {
                return NotFound();
            }

            var dto = new CustomerDto
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
            var customer = _customerService.GetCustomerById(id);

            if (customer == null)
            {
                return NotFound();
            }

            _customerService.DeleteCustomer(id);

            return RedirectToAction(nameof(Index));
        }
    }
}