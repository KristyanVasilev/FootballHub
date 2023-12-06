using Microsoft.AspNetCore.Http;

namespace FootballHub.Application.Models.DTOs
{
    public class ProductFormDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public IFormFile Image { get; set; } = null!;
    }
}
