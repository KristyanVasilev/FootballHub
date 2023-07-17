using Marek.Application.Config;
using Marek.Application.Interfaces;
using Marek.Application.Models.FixturesDataModels;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace Marek.Application.Services
{
    public class FixturesService : IFixtureService
    {
        private readonly IGetApiInfoService _getApiInfoService;
        private readonly ApiConfig _apiConfig;
       // private readonly IMemoryCache _cache;

        public FixturesService(IGetApiInfoService getApiInfoService, IOptions<ApiConfig> apiConfigOptions)
        {
            _getApiInfoService = getApiInfoService;
            //_cache = cache;
            _apiConfig = apiConfigOptions.Value;
        }

        public async Task<ApiResponse> GetAllFixturesInfo()
        {
            try
            {
                var originalData = await _getApiInfoService.GetApiResponse<ApiResponse>("https://api-football-v1.p.rapidapi.com/v3/fixtures?season=2023&team=8543");

                return originalData;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred: {ex.Message}");
            }
        }

        public async Task<Modified> GetCurrentGameInfo()
        {
            try
            {
                var originalData = await _getApiInfoService.GetApiResponse<Api2Response>("https://api-football-v1.p.rapidapi.com/v3/fixtures?season=2023&team=8543");

                var filteredData = originalData.response.FirstOrDefault(x => x.Fixture.status.@short == "NS");

                return filteredData;
            }
            catch (Exception ex)
            {
                // Handle any exceptions here
                Console.WriteLine(ex);
                return null; // Return an appropriate value or handle the error case
            }
        }
        //public async Task<Modified> GetCurrentGameInfo(CancellationToken cancellationToken = default)
        //{
        //    string cacheKey = "CurrentGameInfo";

        //    if (!_cache.TryGetValue(cacheKey, out Modified currentGameInfo))
        //    {
        //        var originalData = await _getApiInfoService.GetApiResponse<Api2Response>("https://api-football-v1.p.rapidapi.com/v3/fixtures?season=2023&team=8543");

        //        var filteredData = originalData.response.FirstOrDefault(x => x.Fixture.status.@short == "NS");

        //        currentGameInfo = filteredData;

        //        var cacheOptions = new MemoryCacheEntryOptions()
        //            .SetAbsoluteExpiration(TimeSpan.FromDays(3)); // Cache for 3 days

        //        _cache.Set(cacheKey, currentGameInfo, cacheOptions);
        //    }

        //    // Run background task to refresh the data every 3 days
        //    Task.Run(async () =>
        //    {
        //        await RefreshGameInfoPeriodically(cancellationToken);
        //    }, cancellationToken);

        //    return currentGameInfo;
        //}

        //private async Task RefreshGameInfoPeriodically(CancellationToken cancellationToken)
        //{
        //    while (!cancellationToken.IsCancellationRequested)
        //    {
        //        await Task.Delay(TimeSpan.FromDays(3), cancellationToken); // Delay for 3 days

        //        var originalData = await _getApiInfoService.GetApiResponse<Api2Response>("https://api-football-v1.p.rapidapi.com/v3/fixtures?season=2023&team=8543");

        //        var filteredData = originalData.response.FirstOrDefault(x => x.Fixture.status.@short == "NS");

        //        var cacheOptions = new MemoryCacheEntryOptions()
        //            .SetAbsoluteExpiration(TimeSpan.FromDays(3)); // Cache for 3 days

        //        _cache.Set("CurrentGameInfo", filteredData, cacheOptions);
        //    }
        //}

        public async Task<List<Modified>> GetFixturesInfo()
        {
            try
            {
                var originalData = await _getApiInfoService.GetApiResponse<Api2Response>("https://api-football-v1.p.rapidapi.com/v3/fixtures?season=2023&team=8543");

                var filteredData = originalData.response.Where(x => x.Fixture.status.@short == "FT").ToList();

                return filteredData;
            }
            catch (Exception ex)
            {
                // Handle any exceptions here
                Console.WriteLine(ex);
                return null; // Return an appropriate value or handle the error case
            }
        }

        public Task<Modified> GetGameInfo()
        {
            throw new NotImplementedException();
        }
    }
}
