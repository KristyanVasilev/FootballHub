namespace Marek.Application.Models.StandingsDataModels
{
    public class StatisticDataModel
    {
        public string Played { get; set; }  = null!;
        public string Win { get; set; } = null!;
        public string Draw { get; set; } = null!;
        public string Lose { get; set; } = null!;
        public GoalDataModel Goals { get; set; } = null!;
    }
}
