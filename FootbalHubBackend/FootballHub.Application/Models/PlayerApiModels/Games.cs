namespace FootballHub.Application.Models.PlayerApiModels
{
    public class Games
    {
        public int? Appearences { get; set; }
        public int? Lineups { get; set; }
        public int? Minutes { get; set; }
        public string Position { get; set; } = null!;
        public bool Captain { get; set; }
    }
}