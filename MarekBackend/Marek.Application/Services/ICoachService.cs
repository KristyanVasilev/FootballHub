namespace Marek.Application.Services
{
    public interface ICoachService
    {
        Task<ModifiedDataModel> GetDataFromApi();
    }
}
