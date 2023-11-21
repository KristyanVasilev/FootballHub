namespace FootballHub.Application.Models.FixtureApiModels
{
    public class Venue
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string City { get; set; } = null!;
    }
}