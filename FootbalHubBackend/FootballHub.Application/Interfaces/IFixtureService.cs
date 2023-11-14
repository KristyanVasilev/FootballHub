using FootballHub.Application.Models.FixturesDataModels;

namespace FootballHub.Application.Interfaces
{
    public interface IFixtureService
    {
        Task<ApiResponse> GetAllFixturesInfo();
        Task<List<Modified>> GetFixturesInfo();
        Task<Modified> GetCurrentGameInfo();
        Task<Modified> GetGameInfo();

    }
}
