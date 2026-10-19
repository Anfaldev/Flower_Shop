using Flower_Shop.Application.Dtos.CartDtos;
using Flower_Shop.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Flower_Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        // GET: api/Cart/3
        [HttpGet("{userId}")]
        public IActionResult GetCart(int userId)
        {
            var items = _cartService.GetCart(userId);

            return Ok(items);
        }

        // POST: api/Cart
        [HttpPost]
        public IActionResult AddToCart([FromBody] AddCartDto dto)
        {
            if (dto.Quantity < 1)
                return BadRequest("Invalid quantity");

            var result = _cartService.AddToCart(dto);

            if (!result)
                return BadRequest("Product not found or could not be added to cart");

            return Ok(new { message = "Added to cart" });
        }

        // DELETE: api/Cart/3/5
        [HttpDelete("{userId}/{productId}")]
        public IActionResult RemoveFromCart(int userId, int productId)
        {
            var result = _cartService.RemoveFromCart(userId, productId);

            if (!result)
                return NotFound("Cart item not found");

            return Ok(new { message = "Removed from cart" });
        }
    }
}