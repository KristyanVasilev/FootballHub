using FootballHub.Application.Models.PlayerApiModels;
namespace FootballHub.Application.Interfaces
{
    public interface ITeamService
    {
        Task<PlayerRotoObject> GetPlayersInfo();
        Task<string> Test();
    }
}
