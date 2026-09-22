using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Flower_Shop.Models;
using Flower_Shop.Data;
using Flower_Shop.Dtos.ProductsDtos;
using Flower_Shop.Repositories;

namespace Flower_Shop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepository _repository;
        private readonly AppDbContext _db;

        public ProductsController(
            IProductRepository repository,
            AppDbContext db)
        {
            _repository = repository;
            _db = db;
        }

        public IActionResult Index()
        {
            var products = _repository
                .GetAll()
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    UID = p.UID,
                    Name = p.Name,
                    Price = p.Price,
                    Stock = p.Stock,
                    ImageUrl = p.ImageUrl,
                    CategoryId = p.CategoryId,
                    CategoryName = _db.Categories
                        .Where(c => c.Id == p.CategoryId)
                        .Select(c => c.Name)
                        .FirstOrDefault()
                })
                .ToList();

            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(
                _db.Categories,
                "Id",
                "Name"
            );

            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateProductDto dto)
        {
            if (ModelState.IsValid)
            {
                Product product = new Product
                {
                    Name = dto.Name,
                    Price = dto.Price,
                    Stock = dto.Stock,
                    ImageUrl = dto.ImageUrl,
                    CategoryId = dto.CategoryId
                };

                _repository.Add(product);
                _repository.Save();

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categories = new SelectList(
                _db.Categories,
                "Id",
                "Name",
                dto.CategoryId
            );

            return View(dto);
        }

        [HttpGet]
        public IActionResult Edit(string uid)
        {
            var product = _repository.GetByUId(uid);

            if (product == null)
            {
                return NotFound();
            }

            var dto = new UpdateProductDto
            {
                Id = product.Id,
                UID = product.UID,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock,
                ImageUrl = product.ImageUrl,
                CategoryId = product.CategoryId
            };

            ViewBag.Categories = new SelectList(
                _db.Categories,
                "Id",
                "Name",
                dto.CategoryId
            );

            return View(dto);
        }

        [HttpPost]
        public IActionResult Edit(UpdateProductDto dto)
        {
            if (ModelState.IsValid)
            {
                var product = _repository.GetById(dto.Id);

                if (product == null)
                {
                    return NotFound();
                }

                product.Name = dto.Name;
                product.Price = dto.Price;
                product.Stock = dto.Stock;
                product.ImageUrl = dto.ImageUrl;
                product.CategoryId = dto.CategoryId;

                _repository.Update(product);
                _repository.Save();

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categories = new SelectList(
                _db.Categories,
                "Id",
                "Name",
                dto.CategoryId
            );

            return View(dto);
        }

        [HttpGet]
        public IActionResult Delete(string uid)
        {
            var product = _repository.GetByUId(uid);

            if (product == null)
            {
                return NotFound();
            }

            var dto = new ProductDto
            {
                Id = product.Id,
                UID = product.UID,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock,
                ImageUrl = product.ImageUrl,
                CategoryId = product.CategoryId,
                CategoryName = _db.Categories
                    .Where(c => c.Id == product.CategoryId)
                    .Select(c => c.Name)
                    .FirstOrDefault()
            };

            return View(dto);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = _repository.GetById(id);

            if (product == null)
            {
                return NotFound();
            }

            _repository.Delete(product);
            _repository.Save();

            return RedirectToAction(nameof(Index));
        }
    }
}