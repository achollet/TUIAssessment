using System;
using System.Collections.Generic;
using TUIAssessmentBuisness.Models;
using TUIAssessmentBuisness.Services;
using TUIAssessment.DAL;
using TUIAssessment.DAL.Entities;

namespace TUIAssessmentBuisness
{
    public class FlightBusiness : IFlightBusiness
    {
        private readonly IAirportBusiness _airportBusiness;
        private readonly IFlightService _flightService;
        private readonly ITUIAssessmentDAL _TUIAssessmentDAL;
        private readonly double _speed = 960.0;
        private readonly double _fuelConsumption = 800.0;

        public FlightBusiness(IAirportBusiness airportBusiness, IFlightService flightService, ITUIAssessmentDAL tUIAssessmentDAL)
        {
            _airportBusiness = airportBusiness;
            _flightService = flightService;
            _TUIAssessmentDAL = tUIAssessmentDAL;
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

            var flightEntity = SetFlightEntity(flight);

            _TUIAssessmentDAL.SaveFlightEntity(flightEntity);

            return flight;
        }

        public IEnumerable<FlightModel> GetAllFlights()
        {
            var flightModels = new List<FlightModel>();
            var flightEntities = _TUIAssessmentDAL.GetFlightEntities();

            foreach (var flightEntity in flightEntities)
            {
                var flight = SetFlightFromFlightEntity(flightEntity);
                flightModels.Add(flight);
            }

            return flightModels;
        }

        public bool DeleteFlightById(int flightId)
        {
            return _TUIAssessmentDAL.RemoveFlightEntityByID(flightId);
        }

        public FlightModel UpdateFlight(FlightModel flight)
        {
            var flightEntityToUpdate = SetFlightEntity(flight);

            var flightEntityUpdated = _TUIAssessmentDAL.UpdateFlightEntity(flightEntityToUpdate);

            return SetFlightFromFlightEntity(flightEntityUpdated);
        }

        private FlightEntity SetFlightEntity(FlightModel flight)
        {
            return new FlightEntity
            {
                DepartureAirportId = flight.DepartureAirport.Id,
                ArrivalAirportId = flight.ArrivalAirport.Id,
                Distance = flight.Distance,
                FuelQuantity = flight.Carburant,
                TimeOfFlight = flight.Duration,
                Creation = flight.Creation
            };
        }

        private FlightModel SetFlightFromFlightEntity(FlightEntity flightEntity)
        {
            var flight = new FlightModel
            {
                ID = flightEntity.Id,
                Distance = flightEntity.Distance,
                Carburant = flightEntity.FuelQuantity,
                Duration = flightEntity.TimeOfFlight,
                Creation = flightEntity.Creation,
                Update = flightEntity.Update
            };

            flight.DepartureAirport = _airportBusiness.GetAirportById(flightEntity.DepartureAirportId);
            flight.ArrivalAirport = _airportBusiness.GetAirportById(flightEntity.ArrivalAirportId);

            return flight;
        }
    }
}