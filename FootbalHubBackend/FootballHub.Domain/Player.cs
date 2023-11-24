namespace FootballHub.Domain
{
    using FootballHub.Domain.Models;

    public class Player : BaseDeletableModel<int>
    {
        public string Name { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int? Age { get; set; }
        public Birth Birth { get; set; } = null!;
        public string Nationality { get; set; } = null!;
        public string Photo { get; set; } = null!;
        public bool Injured { get; set; }
    }
}
