namespace FootballHub.Application.Models.PlayerApiModels
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Logo { get; set; } = null!;
    }
}