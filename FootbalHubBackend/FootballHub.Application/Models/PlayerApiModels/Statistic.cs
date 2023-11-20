namespace FootballHub.Application.Models.PlayerApiModels
{
    public class Statistic
    {
        public Team Team { get; set; } = null!;
        public League League { get; set; } = null!;
        public Games Games { get; set; } = null!;
        public Goals Goals { get; set; } = null!;
        public Cards Cards { get; set; } = null!;
    }
}