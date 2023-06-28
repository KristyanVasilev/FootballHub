namespace Marek.Application.Services
{
    using Marek.Application.Config;
    using Marek.Application.Interfaces;
    using Microsoft.Extensions.Options;
    using Newtonsoft.Json;

    public class GetApiInfoService : IGetApiInfoService
    {

        private readonly HttpClient _httpClient;
        private readonly ApiConfig _apiConfig;

        public GetApiInfoService(HttpClient httpClient, IOptions<ApiConfig> apiConfigOptions)
        {
            _httpClient = httpClient;
            _apiConfig = apiConfigOptions.Value;
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Key", _apiConfig.RapidApiKey);
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Host", _apiConfig.RapidApiHost);
        }

        public async Task<T> GetApiResponse<T>(string url)
        {
            using (var response = await _httpClient.GetAsync(url))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(body);
            }
        }
    }
}
