namespace FootballHub.Application.Models.StandingsDataModels
{
    public class StandingsAllApiModel
    {
        public int Played { get; set; }
        public int Win { get; set; }
        public int Draw { get; set; }
        public int Lose { get; set; }
        public StandingsGoalsApiModel Goals { get; set; } = null!;
    }
}
