namespace Marek.Application.Services
{
    public class ModifiedDataModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public string PhotoUrl { get; set; }
        public string Nationality { get; set; }
        public List<CareerData> Career { get; set; }
    }
}