namespace FootballHub.Presentation.Controllers
{
    using FootballHub.Application.Interfaces;
    using FootballHub.Application.Models.DTOs;
    using FootballHub.Application.Services;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class ShopController : Controller
    {
        private readonly IShopService _shopService;

        public ShopController(IShopService shopService)
        {
            _shopService = shopService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateProduct([FromForm] ProductFormDto form)
        {
            try
            {
                // Validate required fields
                if (string.IsNullOrEmpty(form.ProductName) || string.IsNullOrEmpty(form.Description) || form.Price == 0)
                {
                    return BadRequest("All fields are required");
                }

                await _shopService.CreateProduct(form);

                return CreatedAtAction(nameof(CreateProduct), new { message = "Product created successfully" });
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error creating product: {ex}");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
