namespace FootballHub.Application.Interfaces
{
    using FootballHub.Application.Models.StandingsDataModels;

    public interface IStandingsService
    {
        Task<StandingsRotoObject> GetStandingsInfo();
    }
}
