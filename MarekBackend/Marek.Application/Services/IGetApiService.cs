namespace Marek.Application.Services
{
    public interface GetApiResponse
    {
        Task<T> GetApiResponse<T>(string url);
    }
}
