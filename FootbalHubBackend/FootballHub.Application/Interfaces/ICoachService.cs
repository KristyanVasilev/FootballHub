using FootballHub.Application.Models.CoachDataModels;

namespace FootballHub.Application.Interfaces
{
    public interface ICoachService
    {
        Task<ModifiedCoachDataModel> GetCoachInfo();
    }
}
