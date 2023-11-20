namespace FootballHub.Application.Models.PlayerApiModels
{
    public class Response
    {
        public Player Player { get; set; } = null!;
        public Statistic[] Statistics { get; set; } = null!;
    }
}