namespace FootballHub.Application.Models.DTOs
{
    public class EditProductFormDto
    {
        public string ProductName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
