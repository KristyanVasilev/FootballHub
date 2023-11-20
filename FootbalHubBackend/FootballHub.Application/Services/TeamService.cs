using FootballHub.Application.Config;
using FootballHub.Application.Interfaces;
using FootballHub.Application.Models.PlayerApiModels;
namespace FootballHub.Application.Services
{
    using Microsoft.Extensions.Options;

    public class TeamService : ITeamService
    {
        private readonly IGetApiInfoService _getApiInfoService;
        private readonly ApiConfig _apiConfig;

        public TeamService(IGetApiInfoService getApiInfoService, IOptions<ApiConfig> apiConfigOptions)
        {
            _getApiInfoService = getApiInfoService;
            _apiConfig = apiConfigOptions.Value;
        }

        public async Task<PlayerRotoObject> GetPlayersInfo()
        {
            try
            {
                var players = await _getApiInfoService.GetApiResponse<PlayerRotoObject>(_apiConfig.TeamApiUrl);

                return players;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred: {ex.Message}");
            }
        }
    }
}
