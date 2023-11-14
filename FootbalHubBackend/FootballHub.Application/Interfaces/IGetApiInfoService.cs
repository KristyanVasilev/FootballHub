namespace FootballHub.Application.Interfaces
{
    public interface IGetApiInfoService
    {
        Task<T> GetApiResponse<T>(string url);
    }
}