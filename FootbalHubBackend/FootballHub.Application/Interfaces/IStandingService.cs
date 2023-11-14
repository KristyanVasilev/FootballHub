using FootballHub.Application.Models.StandingsDataModels;

namespace FootballHub.Application.Interfaces
{
    public interface IStandingService
    {
        Task<APIResponseDataModel> GetStandingInfo();

    }
}
