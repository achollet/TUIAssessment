using System;
using System.Collections.Generic;
using TUIAssessmentBuisness.Models;

namespace TUIAssessmentBuisness
{
    public class FlightBusiness : IFlightBusiness
    {
        public FlightModel CreateFlight(int departureAirportId, int arrivalAirportId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FlightModel> GetAllFlights()
        {
            throw new NotImplementedException();
        }

        public FlightModel UpdateFlightById(int flightId)
        {
            throw new NotImplementedException();
        }
    }
}