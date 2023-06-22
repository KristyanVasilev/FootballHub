namespace Marek.Application.Services
{
    public class CoachService : ICoachService
    {
        private readonly IGetApiInfoService _getApiInfoService;

        public CoachService(IGetApiInfoService getApiInfoService)
        {
            _getApiInfoService = getApiInfoService;
        }
        public async Task<ModifiedDataModel> GetDataFromApi()
        {
            try
            {
                var url = "https://api-football-v1.p.rapidapi.com/v3/coachs?team=8543";
                var originalData = await _getApiInfoService.GetApiResponse<OriginalDataModel>(url);

                var modifiedDataList = originalData.Response
                    .Where(coachData => coachData.Career
                    .Any(careerData => careerData.Team.Name == "Marek" && careerData.End == null))
                    .SelectMany(coachData => coachData.Career.Select(careerData => new ModifiedDataModel
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
