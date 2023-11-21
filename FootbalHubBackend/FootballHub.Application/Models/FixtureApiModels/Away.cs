namespace FootballHub.Application.Models.FixtureApiModels
{
    public class Away
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Logo { get; set; } = null!;
        public bool? Winner { get; set; }
    }
}