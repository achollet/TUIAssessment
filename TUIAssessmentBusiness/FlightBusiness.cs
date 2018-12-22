using System;
using System.Collections.Generic;
using TUIAssessmentBusiness.Models;
using TUIAssessmentBusiness.Services;
using TUIAssessmentBusiness.Interfaces;

namespace TUIAssessmentBusiness
{
    public class FlightBusiness : IFlightBusiness
    {
        private readonly IAirportBusiness _airportBusiness;
        private readonly IFlightService _flightService;
        private readonly IFlightRepository _flightRepository;
        private readonly double _speed = 960.0;
        private readonly double _fuelConsumption = 800.0;

        public FlightBusiness(IAirportBusiness airportBusiness, IFlightService flightService, IFlightRepository flightRepository)
        {
            _airportBusiness = airportBusiness;
            _flightService = flightService;
            _flightRepository = flightRepository;
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
                flight.Carburant = _flightService.CalculateFuelVolumeForFlight(flight.Distance, _fuelConsumption, departureAirport.TakeOffEffort);
            }

            flight.Creation = DateTime.Today;

            _flightRepository.SaveFlight(flight);

            return flight;
        }

        public IEnumerable<FlightModel> GetAllFlights() => _flightRepository.GetFlights();

        public bool DeleteFlightById(int flightId) => _flightRepository.RemoveFlightByID(flightId);

        public FlightModel UpdateFlight(FlightModel flight) => _flightRepository.UpdateFlight(flight);

        //private FlightEntity SetFlightEntity(FlightModel flight)
        // {
        //     return new FlightEntity
        //     {
        //         DepartureAirportId = flight.DepartureAirport.Id,
        //         ArrivalAirportId = flight.ArrivalAirport.Id,
        //         Distance = flight.Distance,
        //         FuelQuantity = flight.Carburant,
        //         TimeOfFlight = flight.Duration,
        //         Creation = flight.Creation
        //     };
        // }

        // private FlightModel SetFlightFromFlightEntity(FlightEntity flightEntity)
        // {
        //     var flight = new FlightModel
        //     {
        //         ID = flightEntity.Id,
        //         Distance = flightEntity.Distance,
        //         Carburant = flightEntity.FuelQuantity,
        //         Duration = flightEntity.TimeOfFlight,
        //         Creation = flightEntity.Creation,
        //         Update = flightEntity.Update
        //     };

        //     flight.DepartureAirport = _airportBusiness.GetAirportById(flightEntity.DepartureAirportId);
        //     flight.ArrivalAirport = _airportBusiness.GetAirportById(flightEntity.ArrivalAirportId);

        //     return flight;
        // }
    }
}