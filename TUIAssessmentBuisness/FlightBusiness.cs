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
        private readonly double _speed = 960.0;
        private readonly double _fuelConsumption = 800.0;

        public FlightBusiness(IAirportBusiness airportBusiness, IFlightService flightService)
        {
            _airportBusiness = airportBusiness;
            _flightService = flightService;
        }

        public FlightModel CreateFlight(int departureAirportId, int arrivalAirportId)
        {
            var flight = new FlightModel();

            var arrivalAirport = _airportBusiness.GetAirportById(arrivalAirportId);
            var departureAirport = _airportBusiness.GetAirportById(departureAirportId);

            flight.ArrivalAirport = arrivalAirport ?? new AirportModel();
            flight.DepartureAirport = departureAirport ?? new AirportModel();

            if (arrivalAirport != null && departureAirport != null)
            {
                flight.Distance = _flightService.CalculateDistanceWithHaversineFormulae(arrivalAirport.Coordinates, departureAirport.Coordinates);
                flight.Duration = _flightService.CalculateTimeOfFlight(flight.Distance, _speed);
                flight.Carburant = _flightService.CalculateFuelVolumeForFlight(flight.Distance, _fuelConsumption , departureAirport.TakeOffEffort);
            }

            flight.Creation = DateTime.Today.ToShortDateString();

            return flight;
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