namespace FootballHub.Application.Models.FixtureApiModels
{
    public class Fixture
    {
        public int Id { get; set; }
        public string Referee { get; set; } = null!;
        public DateTime Date { get; set; }
        public int Timestamp { get; set; }
        public Venue Venue { get; set; } = null!;
        public Status Status { get; set; } = null!;
    }
}