using FootballHub.Application.Config;
using FootballHub.Application.Interfaces;
using FootballHub.Application.Models.FixtureApiModels;
using FootballHub.Application.Models.FixturesDataModels;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace FootballHub.Application.Services
{
    public class FixtureService : IFixtureService
    {
        private readonly IGetApiInfoService _getApiInfoService;
        private readonly ApiConfig _apiConfig;

        public FixtureService(IGetApiInfoService getApiInfoService, IOptions<ApiConfig> apiConfigOptions)
        {
            _getApiInfoService = getApiInfoService;
            _apiConfig = apiConfigOptions.Value;
        }

        public async Task<ApiResponse> GetAllFixturesInfo()
        {
            try
            {
                var allFixtures = await _getApiInfoService.GetApiResponse<ApiResponse>("https://api-football-v1.p.rapidapi.com/v3/fixtures?team=8543&last=50");

                return allFixtures;
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
                Console.WriteLine(ex);
                return null; // Return an appropriate value or handle the error case
            }
        }

        public Task<Modified> GetGameInfo()
        {
            throw new NotImplementedException();
        }

        public async Task<LatestFixturesRotoObject> GetLatetsFixturesInfo()
        {
            try
            {
                var latestFixtures = await _getApiInfoService.GetApiResponse<LatestFixturesRotoObject>("https://api-football-v1.p.rapidapi.com/v3/fixtures?team=8543&last=2");

                return latestFixtures;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred: {ex.Message}");
            }
        }

        public async Task<NextFixturesRotoObject> GetNextFixturesInfo()
        {
            try
            {
                var nextFixtures = await _getApiInfoService.GetApiResponse<NextFixturesRotoObject>("https://api-football-v1.p.rapidapi.com/v3/fixtures?team=8543&next=10");

                return nextFixtures;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred: {ex.Message}");
            }
        }

        public async Task<Api2Response> GetNextGameInfo()
        {
            try
            {
                var originalData = await _getApiInfoService.GetApiResponse<Api2Response>("https://api-football-v1.p.rapidapi.com/v3/fixtures?team=8543&next=10");

                //var filteredData = originalData.response.FirstOrDefault(x => x.Fixture.status.@short == "NS");

                return originalData;
            }
            catch (Exception ex)
            {
                // Handle any exceptions here
                Console.WriteLine(ex);
                return null; // Return an appropriate value or handle the error case
            }
        }
    }
}
