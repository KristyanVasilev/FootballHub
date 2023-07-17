using Marek.Application.Models.FixturesDataModels;

namespace Marek.Application.Interfaces
{
    public interface IFixtureService
    {
        Task<ApiResponse> GetAllFixturesInfo();
        Task<List<Modified>> GetFixturesInfo();
        Task<Modified> GetCurrentGameInfo();
        Task<Modified> GetGameInfo();

    }
}
