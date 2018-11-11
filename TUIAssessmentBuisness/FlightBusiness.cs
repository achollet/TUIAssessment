using System;
using System.Collections.Generic;
using TUIAssessmentBuisness.Models;
using TUIAssessmentBuisness.Services;

namespace TUIAssessmentBuisness
{
    public class FlightBusiness : IFlightBusiness
    {
        private readonly IAirportBusiness _airportBusiness;
        private readonly IFlightService _flightService;

        public FlightBusiness(IAirportBusiness airportBusiness, IFlightService flightService)
        {
            _airportBusiness = airportBusiness;
            _flightService = flightService;
        }

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