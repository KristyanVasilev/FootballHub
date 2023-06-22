namespace Marek.Application.Services
{
    public interface IGetApiInfoService
    {
        Task<T> GetApiResponse<T>(string url);
    }
}