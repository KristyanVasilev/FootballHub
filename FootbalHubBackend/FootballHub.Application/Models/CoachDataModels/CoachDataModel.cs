namespace FootballHub.Application.Models.CoachDataModels
{
    public class CoachDataModel
    {
        public string FirstName { get; set; } = null!; 
        public string LastName { get; set; } = null!;
        public string Nationality { get; set; } = null!;
        public string Age { get; set; } = null!; 
        public string Photo { get; set; } = null!;
        public List<CoachCareerDataModel> Career { get; set; } = null!;
    }
}
