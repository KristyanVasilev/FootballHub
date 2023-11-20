namespace FootballHub.Application.Models.PlayerApiModels
{
    public class League
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string Logo { get; set; } = null!;
        public string Flag { get; set; } = null!;
        public int Season { get; set; }
    }
}