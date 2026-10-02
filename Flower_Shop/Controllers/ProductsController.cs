using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Flower_Shop.Application.Services;
using Flower_Shop.Application.Dtos.ProductsDtos;

namespace Flower_Shop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            var products = _productService.GetAllProducts();

            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(
                _productService.GetAllCategories(),
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
                _productService.AddProduct(dto);

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categories = new SelectList(
                _productService.GetAllCategories(),
                "Id",
                "Name",
                dto.CategoryId
            );

            return View(dto);
        }

        [HttpGet]
        public IActionResult Edit(string uid)
        {
            var product = _productService.GetProductByUid(uid);

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
                _productService.GetAllCategories(),
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
                var product = _productService.GetProductById(dto.Id);

                if (product == null)
                {
                    return NotFound();
                }

                _productService.UpdateProduct(dto);

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categories = new SelectList(
                _productService.GetAllCategories(),
                "Id",
                "Name",
                dto.CategoryId
            );

            return View(dto);
        }

        [HttpGet]
        public IActionResult Delete(string uid)
        {
            var product = _productService.GetProductByUid(uid);

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
                CategoryName = _productService
                    .GetAllCategories()
                    .FirstOrDefault(c => c.Id == product.CategoryId)?.Name
            };

            return View(dto);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = _productService.GetProductById(id);

            if (product == null)
            {
                return NotFound();
            }

            _productService.DeleteProduct(id);

            return RedirectToAction(nameof(Index));
        }
    }
}