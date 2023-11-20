namespace FootballHub.Application.Models.PlayerApiModels
{
    public class PlayerStatisticsApiModel
    {
        public PlayerTeamApiModel Team { get; set; } = null!;
        public PlayerLeagueApiModel League { get; set; } = null!;
        public PlayerGamesApiModel Games { get; set; } = null!;
        public PlayerGoalsApiModel Goals { get; set; } = null!;
        public PlayerCardsApiModel Cards { get; set; } = null!;
    }
}