using System.Collections.Generic;
using TUIAssessmentBusiness.Models;

namespace TUIAssessmentBusiness.Interfaces
{
    public interface IAirportRepository
    {
        AirportModel GetAirportModelByID(int Id);
        IEnumerable<AirportModel> GetAirportModels();
    }
}