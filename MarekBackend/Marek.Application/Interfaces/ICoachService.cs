using Marek.Application.Models.CoachDataModels;

namespace Marek.Application.Interfaces
{
    public interface ICoachService
    {
        Task<ModifiedCoachDataModel> GetCoachInfo();
    }
}
