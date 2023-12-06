namespace FootballHub.Presentation.Controllers
{
    using FootballHub.Application.Interfaces;
    using FootballHub.Application.Models.DTOs;
    using FootballHub.Application.Services;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.SqlServer.Server;

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

        [HttpGet("getAll")]
        public IActionResult GetAllProducts()
        {
            try
            {
                var products = _shopService.GetAllProducts();
                return Ok(products);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error searching products: {ex}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("getProductById")]
        public IActionResult GetProductById(int productId)
        {
            try
            {
                var product = _shopService.GetProductById(productId);
                return Ok(product);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error searching a product: {ex}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("delete/{productId}")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            try
            {
                await _shopService.DeleteProduct(productId);
                return Ok(new { message = "Product deleted successfully" });
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error deleting product: {ex}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("edit/{productId}")]
        public async Task<IActionResult> EditProduct([FromForm] EditProductFormDto formData, int productId)
        {
            try
            {
                await _shopService.EditProduct(formData, productId);
                return Ok(new { message = "Product edited successfully" });
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error editing product: {ex}");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
