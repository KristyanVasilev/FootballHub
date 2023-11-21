using FootballHub.Application.Models.FixtureApiModels;
using FootballHub.Application.Models.FixturesDataModels;

namespace FootballHub.Application.Interfaces
{
    public interface IFixtureService
    {
        Task<ApiResponse> GetAllFixturesInfo();
        Task<LatestFixturesRotoObject> GetLatetsFixturesInfo();
        Task<NextFixturesRotoObject> GetNextFixturesInfo();
        Task<List<Modified>> GetFixturesInfo();
        Task<Modified> GetCurrentGameInfo();
        Task<Modified> GetGameInfo();
        Task<Api2Response> GetNextGameInfo();

    }
}
