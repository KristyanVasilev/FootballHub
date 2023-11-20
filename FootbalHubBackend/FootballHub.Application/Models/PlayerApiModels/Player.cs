namespace FootballHub.Application.Models.PlayerApiModels
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public int? Age { get; set; }
        public Birth Birth { get; set; } = null!;
        public string Nationality { get; set; } = null!;
        public bool Injured { get; set; }
    }
}