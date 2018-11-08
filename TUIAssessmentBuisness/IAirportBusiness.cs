using System.Collections.Generic;
using TUIAssessmentBuisness.Models;
namespace TUIAssessmentBuisness
{
    public interface IAirportBusiness
    {
        IEnumerable<AirportModel> GetAllAirports();
        AirportModel GetAirportById(int id);
    }
}