namespace FootballHub.Application.Models.PlayerApiModels
{
    public class PlayerApiModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public int? Age { get; set; }
        public PlayerBirthApiModel Birth { get; set; } = null!;
        public string Nationality { get; set; } = null!;
        public string Photo { get; set; } = null!;
        public bool Injured { get; set; }
    }
}