using System.Collections.Generic;
using TUIAssessmentBuisness.Models;
namespace TUIAssessmentBuisness
{
    public interface IFlightBusiness
    {
        FlightModel CreateFlight(int departureAirportId, int arrivalAirportId);
        FlightModel UpdateFlightById(int flightId);
        IEnumerable<FlightModel> GetAllFlights();
    }
}
