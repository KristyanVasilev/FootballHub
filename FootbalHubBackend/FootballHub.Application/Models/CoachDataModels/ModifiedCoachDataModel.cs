namespace FootballHub.Application.Models.CoachDataModels
{
    public class ModifiedCoachDataModel
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Age { get; set; } = null!;
        public string PhotoUrl { get; set; } = null!;
        public string Nationality { get; set; } = null!;
        public List<CoachCareerDataModel> Career { get; set; } = null!;
    }
}