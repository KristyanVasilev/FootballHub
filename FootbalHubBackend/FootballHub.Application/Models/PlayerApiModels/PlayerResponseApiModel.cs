namespace FootballHub.Application.Models.PlayerApiModels
{
    public class PlayerResponseApiModel
    {
        public PlayerApiModel Player { get; set; } = null!;
        public PlayerStatisticsApiModel[] Statistics { get; set; } = null!;
    }
}