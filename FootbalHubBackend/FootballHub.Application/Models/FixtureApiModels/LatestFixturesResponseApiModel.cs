namespace FootballHub.Application.Models.FixtureApiModels
{
    public class LatestFixturesResponseApiModel
    {
        public Fixture Fixture { get; set; } = null!;
        public League League { get; set; } = null!;
        public Teams Teams { get; set; } = null!;
        public Goals Goals { get; set; } = null!;
    }
}