using Microsoft.AspNetCore.Mvc;
using Flower_Shop.Application.Services;
using Flower_Shop.Application.Dtos.ProductsDtos;

namespace Flower_Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/Products
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = _productService.GetAllProducts();

            return Ok(products);
        }

        // GET: api/Products/5
        [HttpGet("{id:int}")]
        public IActionResult GetProductById(int id)
        {
            var product = _productService.GetProductById(id);

            if (product == null)
            {
                return NotFound(new
                {
                    message = "Product not found"
                });
            }

            return Ok(product);
        }

        // GET: api/Products/uid/abc123
        [HttpGet("uid/{uid}")]
        public IActionResult GetProductByUid(string uid)
        {
            var product = _productService.GetProductByUid(uid);

            if (product == null)
            {
                return NotFound(new
                {
                    message = "Product not found"
                });
            }

            return Ok(product);
        }

        // GET: api/Products/categories
        [HttpGet("categories")]
        public IActionResult GetAllCategories()
        {
            var categories = _productService.GetAllCategories();

            return Ok(categories);
        }

        // POST: api/Products
        [HttpPost]
        public IActionResult AddProduct([FromBody] CreateProductDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _productService.AddProduct(dto);

            return Ok(new
            {
                message = "Product added successfully"
            });
        }

        // PUT: api/Products
        [HttpPut]
        public IActionResult UpdateProduct([FromBody] UpdateProductDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _productService.UpdateProduct(dto);

            return Ok(new
            {
                message = "Product updated successfully"
            });
        }

        // DELETE: api/Products/5
        [HttpDelete("{id:int}")]
        public IActionResult DeleteProduct(int id)
        {
            _productService.DeleteProduct(id);

            return Ok(new
            {
                message = "Product deleted successfully"
            });
        }
    }
}