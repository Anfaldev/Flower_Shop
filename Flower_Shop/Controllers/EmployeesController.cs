using Flower_Shop.Application.Services;
using Flower_Shop.Domain.Models;
using Flower_Shop.Models;
using Microsoft.AspNetCore.Mvc;

namespace Flower_Shop.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IEmployeeFileService _employeeFileService;
        private readonly IWebHostEnvironment _environment;

        public EmployeesController(
            IEmployeeService employeeService,
            IEmployeeFileService employeeFileService,
            IWebHostEnvironment environment)
        {
            _employeeService = employeeService;
            _employeeFileService = employeeFileService;
            _environment = environment;
        }

        public IActionResult Index()
        {
            var employees = _employeeService
                .GetAllEmployees()
                .ToList();

            return View(employees);
        }

      
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(
            Employee employee,
            IFormFile? imageFile)
        {
            if (imageFile != null)
            {
                string folder = Path.Combine(
                    _environment.WebRootPath,
                    "images",
                    "employees"
                );

                Directory.CreateDirectory(folder);

                string fileName =
                    Guid.NewGuid().ToString()
                    + Path.GetExtension(imageFile.FileName);

                string filePath = Path.Combine(
                    folder,
                    fileName
                );

                using (var stream = new FileStream(
                    filePath,
                    FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }

                employee.ImageUrl =
                    "/images/employees/" + fileName;
            }

            _employeeService.AddEmployee(employee);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(string uid)
        {
            var employee =
                _employeeService.GetEmployeeByUid(uid);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(
            Employee employee,
            IFormFile? imageFile)
        {
            var existingEmployee =
                _employeeService.GetEmployeeById(employee.Id);

            if (existingEmployee == null)
            {
                return NotFound();
            }

            existingEmployee.Name = employee.Name;

            if (imageFile != null)
            {
                string folder = Path.Combine(
                    _environment.WebRootPath,
                    "images",
                    "employees"
                );

                Directory.CreateDirectory(folder);

                string fileName =
                    Guid.NewGuid().ToString()
                    + Path.GetExtension(imageFile.FileName);

                string filePath = Path.Combine(
                    folder,
                    fileName
                );

                using (var stream = new FileStream(
                    filePath,
                    FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }

                existingEmployee.ImageUrl =
                    "/images/employees/" + fileName;
            }

            _employeeService.UpdateEmployee(existingEmployee);

            return RedirectToAction(nameof(Index));
        }

      
        public IActionResult View(string uid)
        {
            var employee =
                _employeeService.GetEmployeeByUid(uid);

            if (employee == null)
            {
                return NotFound();
            }

            employee.Files = _employeeFileService
                .GetAllEmployeeFiles()
                .Where(f => f.EmployeeID == employee.Id)
                .ToList();

            return View(employee);
        }

        [HttpGet]
        public IActionResult Delete(string uid)
        {
            var employee = _employeeService.GetEmployeeByUid(uid);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var employee = _employeeService.GetEmployeeById(id);

            if (employee == null)
            {
                return NotFound();
            }

            _employeeService.DeleteEmployee(id);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult AddFile(string uid)
        {
            var employee =
                _employeeService.GetEmployeeByUid(uid);

            if (employee == null)
            {
                return NotFound();
            }

            ViewBag.Employee = employee;

            return View();
        }

   
        [HttpPost]
        public IActionResult AddFile(
            int employeeId,
            string name,
            IFormFile? file)
        {
            if (file == null)
            {
                return View();
            }

            string folder = Path.Combine(
                _environment.WebRootPath,
                "files",
                "employees"
            );

            Directory.CreateDirectory(folder);

            string fileName =
                Guid.NewGuid().ToString()
                + Path.GetExtension(file.FileName);

            string filePath = Path.Combine(
                folder,
                fileName
            );

            using (var stream = new FileStream(
                filePath,
                FileMode.Create))
            {
                file.CopyTo(stream);
            }

            var employeeFile = new EmployeeFile
            {
                Name = name,
                FileURL = "/files/employees/" + fileName,
                EmployeeID = employeeId
            };

            _employeeFileService.AddEmployeeFile(employeeFile);

            var employee =
                _employeeService.GetEmployeeById(employeeId);

            return RedirectToAction(
                nameof(View),
                new
                {
                    uid = employee?.UID
                }
            );
        }
    }
}