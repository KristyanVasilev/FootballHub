namespace Marek.Application.Services
{
    public class OriginalDataModel
        {
            public CoachData[] Response { get; set; }
        }

    public class CoachData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nationality { get; set; }
        public string Age { get; set; }
        public string Photo { get; set; }
        public List<CareerData> Career { get; set; }
    }

    public class CareerData
    {
        public TeamData Team { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
    }

    public class TeamData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
    }
}
