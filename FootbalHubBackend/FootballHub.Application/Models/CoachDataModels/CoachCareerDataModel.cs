namespace FootballHub.Application.Models.CoachDataModels
{
    public class CoachCareerDataModel
    {
        public CoachTeamDataModel Team { get; set; } = null!;
        public string Start { get; set; } = null!;
        public string End { get; set; } = null!;
    }
}
