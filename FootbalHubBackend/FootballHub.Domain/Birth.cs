namespace FootballHub.Domain
{
    using FootballHub.Domain.Models;

    public class Birth : BaseModel<int>
    {
        public string? Date { get; set; }
    }
}
