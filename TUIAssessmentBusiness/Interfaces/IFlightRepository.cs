using System.Collections.Generic;
using TUIAssessmentBusiness.Models;

namespace TUIAssessmentBusiness.Interfaces
{
    public interface IFlightRepository
    {
        FlightModel GetFlightByID(int Id);
        IEnumerable<FlightModel> GetFlights();
        FlightModel UpdateFlight(FlightModel flight);
        FlightModel SaveFlight(FlightModel flight);
        bool RemoveFlightByID(int Id);
    }
}