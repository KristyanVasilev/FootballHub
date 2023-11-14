namespace FootballHub.Application.Models.StandingsDataModels
{
    public class LeagueDataModel
    {
        public string Name { get; set; } = null!;
        public string Logo { get; set; } = null!;
        public string Flag { get; set; } = null!;   
        public int Season { get; set; }
        public List<List<StandingDataModel>> Standings { get; set; } = null!;
    }
}
