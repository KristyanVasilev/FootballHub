namespace FootballHub.Application.Services
{
    using FootballHub.Application.Config;
    using FootballHub.Application.Interfaces;
    using FootballHub.Application.Models.StandingsDataModels;
    using Microsoft.Extensions.Options;

    public class StandingsService : IStandingsService
    {
        private readonly IGetApiInfoService _getApiInfoService;
        private readonly ApiConfig _apiConfig;

        public StandingsService(IGetApiInfoService getApiInfoService, IOptions<ApiConfig> apiConfigOptions)
        {
            _getApiInfoService = getApiInfoService;
            _apiConfig = apiConfigOptions.Value;
        }

        public async Task<StandingsRotoObject> GetStandingsInfo()
        {
            try
            {
                var originalData = await _getApiInfoService.GetApiResponse<StandingsRotoObject>(_apiConfig.StandingsApiUrl);
                                 
                return originalData;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred: {ex.Message}");
            }
        }
    }
}
