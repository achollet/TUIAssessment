using System.Collections.Generic;
using TUIAssessmentBusiness.Models;

namespace TUIAssessmentBusiness.Interfaces
{
    public interface IFlightBusiness
    {
        FlightModel CreateFlight(int departureAirportId, int arrivalAirportId);
        FlightModel UpdateFlight(FlightModel flight);
        bool DeleteFlightById(int flightId);
        IEnumerable<FlightModel> GetAllFlights();
    }
}
