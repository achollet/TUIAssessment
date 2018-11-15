using System.Collections.Generic;
using TUIAssessmentBuisness.Models;
namespace TUIAssessmentBuisness
{
    public interface IFlightBusiness
    {
        FlightModel CreateFlight(int departureAirportId, int arrivalAirportId);
        FlightModel UpdateFlight(FlightModel flight);
        bool DeleteFlightById(int flightId);
        IEnumerable<FlightModel> GetAllFlights();
    }
}
