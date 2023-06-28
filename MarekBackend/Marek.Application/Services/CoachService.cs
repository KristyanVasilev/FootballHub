namespace Marek.Application.Services
{
    using Marek.Application.Config;
    using Marek.Application.Interfaces;
    using Marek.Application.Models.CoachDataModels;
    using Microsoft.Extensions.Options;

    public class CoachService : ICoachService
    {
        private readonly IGetApiInfoService _getApiInfoService;
        private readonly ApiConfig _apiConfig;

        public CoachService(IGetApiInfoService getApiInfoService, IOptions<ApiConfig> apiConfigOptions)
        {
            _getApiInfoService = getApiInfoService;
            _apiConfig = apiConfigOptions.Value;
        }
        public async Task<ModifiedCoachDataModel> GetCoachInfo()
        {
            try
            {
                var originalData = await _getApiInfoService.GetApiResponse<OriginalCoachDataModel>(_apiConfig.CoachApiUrl);

                var modifiedDataList = originalData.Response
                    .Where(coachData => coachData.Career
                    .Any(careerData => careerData.Team.Name == "Marek" && careerData.End == null))
                    .SelectMany(coachData => coachData.Career.Select(careerData => new ModifiedCoachDataModel
                    {
                        FirstName = coachData.FirstName,
                        LastName = coachData.LastName,
                        Nationality = coachData.Nationality,
                        PhotoUrl = coachData.Photo,
                        Career = coachData.Career
                    }))
                    .FirstOrDefault();

                return modifiedDataList;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred: {ex.Message}");
            }
        }
    }
}
