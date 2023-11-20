namespace FootballHub.Application.Models.StandingsDataModels
{
    public class StandingsStandingApiModel
    {
        public int Rank { get; set; }
        public StandingsTeamApiModel Team { get; set; } = null!;
        public int Points { get; set; }
        public int GoalsDiff { get; set; }
        public string Form { get; set; } = null!;
        public string Status { get; set; } = null!;
        public string Description { get; set; } = null!;
        public StandingsAllApiModel All { get; set; } = null!;
        public DateTime Update { get; set; }
    }
}
