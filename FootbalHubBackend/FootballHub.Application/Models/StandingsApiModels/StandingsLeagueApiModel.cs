namespace FootballHub.Application.Models.StandingsDataModels
{
    public class StandingsLeagueApiModel
    {
        public string Name { get; set; } = null!;
        public string Logo { get; set; } = null!;
        public string Flag { get; set; } = null!;
        public int Season { get; set; }
        public StandingsStandingApiModel[][] Standings { get; set; } = null!;
    }
}
