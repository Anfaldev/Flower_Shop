using Flower_Shop.Models;
using Flower_Shop.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Flower_Shop.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeeFileRepository _employeeFileRepository;
        private readonly IWebHostEnvironment _environment;

        public EmployeesController(
            IEmployeeRepository employeeRepository,
            IEmployeeFileRepository employeeFileRepository,
            IWebHostEnvironment environment)
        {
            _employeeRepository = employeeRepository;
            _employeeFileRepository = employeeFileRepository;
            _environment = environment;
        }

        // =========================
        // Index
        // =========================
        public IActionResult Index()
        {
            var employees = _employeeRepository
                .GetAll()
                .ToList();

            return View(employees);
        }

        // =========================
        // Create
        // =========================
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

            _employeeRepository.Add(employee);
            _employeeRepository.Save();

            return RedirectToAction(nameof(Index));
        }

        // =========================
        // Edit
        // =========================
        public IActionResult Edit(string uid)
        {
            var employee =
                _employeeRepository.GetByUId(uid);

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
                _employeeRepository.GetById(employee.Id);

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

            _employeeRepository.Update(existingEmployee);
            _employeeRepository.Save();

            return RedirectToAction(nameof(Index));
        }

        // =========================
        // View
        // =========================
        public IActionResult View(string uid)
        {
            var employee =
                _employeeRepository.GetByUId(uid);

            if (employee == null)
            {
                return NotFound();
            }

            employee.Files = _employeeFileRepository
                .GetAll()
                .Where(f => f.EmployeeID == employee.Id)
                .ToList();

            return View(employee);
        }

        // =========================
        // Add File - GET
        // =========================
        public IActionResult AddFile(string uid)
        {
            var employee =
                _employeeRepository.GetByUId(uid);

            if (employee == null)
            {
                return NotFound();
            }

            ViewBag.Employee = employee;

            return View();
        }

        // =========================
        // Add File - POST
        // =========================
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

            _employeeFileRepository.Add(employeeFile);
            _employeeFileRepository.Save();

            var employee =
                _employeeRepository.GetById(employeeId);

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