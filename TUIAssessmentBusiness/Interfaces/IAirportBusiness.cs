using System.Collections.Generic;
using TUIAssessmentBusiness.Models;

namespace TUIAssessmentBusiness.Interfaces
{
    public interface IAirportBusiness
    {
        IEnumerable<AirportModel> GetAllAirports();
        AirportModel GetAirportById(int id);
    }
}