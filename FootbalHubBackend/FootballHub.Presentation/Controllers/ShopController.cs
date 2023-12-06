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
        public async Task<IActionResult> CreateProduct([FromForm] ProductFormDto formData)
        {
            try
            {
                // Validate required fields
                if (string.IsNullOrEmpty(formData.ProductName) || string.IsNullOrEmpty(formData.Description) || formData.Price == 0)
                {
                    return BadRequest("All fields are required");
                }

                await _shopService.CreateProduct(formData);

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
