namespace FootballHub.Domain
{
    using FootballHub.Domain.Models;

    public class Product : BaseModel<int>
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = null!;
    }
}
