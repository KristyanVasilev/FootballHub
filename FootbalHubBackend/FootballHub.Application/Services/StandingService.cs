﻿namespace FootballHub.Application.Services
{
    using FootballHub.Application.Config;
    using FootballHub.Application.Interfaces;
    using FootballHub.Application.Models.StandingsDataModels;
    using Microsoft.Extensions.Options;

    public class StandingService : IStandingService
    {
        private readonly IGetApiInfoService _getApiInfoService;
        private readonly ApiConfig _apiConfig;

        public StandingService(IGetApiInfoService getApiInfoService, IOptions<ApiConfig> apiConfigOptions)
        {
            _getApiInfoService = getApiInfoService;
            _apiConfig = apiConfigOptions.Value;
        }

        public async Task<APIResponseDataModel> GetStandingInfo()
        {
            try
            {
                var originalData = await _getApiInfoService.GetApiResponse<APIResponseDataModel>(_apiConfig.StandingApiUrl);
                                 
                return originalData;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred: {ex.Message}");
            }
        }
    }
}