using Marek.Application.Models.CoachDataModels;
using Marek.Application.Models.StandingsDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marek.Application.Interfaces
{
    public interface IStandingService
    {
        Task<APIResponseDataModel> GetStandingInfo();

    }
}
