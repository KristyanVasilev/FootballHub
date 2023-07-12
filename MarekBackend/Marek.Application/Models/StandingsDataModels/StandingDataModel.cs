namespace Marek.Application.Models.StandingsDataModels
{
    public class StandingDataModel
    {
        public string Rank { get; set; } = null!;
        public TeamDataModel Team { get; set; } = null!;
        public string Points { get; set; } = null!;
        public string GgoalsDiff { get; set; } = null!;
        public string Status { get; set; } = null!;
        public string Description { get; set; } = null!;
        public StatisticDataModel All { get; set; } = null!;
        public string Update { get; set; } = null!;
    }   
}
