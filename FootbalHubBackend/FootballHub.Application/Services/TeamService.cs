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

        public async Task<RotoObject> GetTeamInfo()
        {
            try
            {
                var originalData = await _getApiInfoService.GetApiResponse<RotoObject>(_apiConfig.TeamApiUrl);

                return originalData;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred: {ex.Message}");
            }
        }
    }
}
