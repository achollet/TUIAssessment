using System.Collections.Generic;
using System.Linq;
using TUIAssessment.DAL.Entities;
using TUIAssessmentBusiness.Models;

namespace TUIAssessment.DAL
{
    public class EntityToModelMapperService : IEntityToModelMapperService
    {
        public AirportModel ConvertToAirportModel(AirportEntity airportEntity)
        {
            return new AirportModel
            {
                Id = airportEntity.Id,
                Code = airportEntity.Code,
                Name = airportEntity.Name,
                Coordinates = new CoordinatesModel(airportEntity.Latitude, airportEntity.Longitude)
            };
        }

        public IEnumerable<AirportModel> ConvertToAirportModels(IEnumerable<AirportEntity> airportEntities)
        {
            return airportEntities.Select(a => ConvertToAirportModel(a));
        }

        public FlightEntity ConvertToFlightEntity(FlightModel flight)
        {
            return new FlightEntity
            {
                Id = flight.ID,
                ArrivalAirportId = flight.ArrivalAirport.Id,
                DepartureAirportId = flight.DepartureAirport.Id,
                Distance = flight.Distance,
                FuelQuantity = flight.Carburant,
                TimeOfFlight = flight.Duration,
                Creation = flight.Creation
            };
        }

        public FlightModel ConvertToFlightModel(FlightEntity flightEntity)
        {
            return new FlightModel
            {
                ID = flightEntity.Id,
                ArrivalAirport = new AirportModel { Id = flightEntity.ArrivalAirportId },
                DepartureAirport = new AirportModel { Id = flightEntity.DepartureAirportId },
                Distance = flightEntity.Distance,
                Carburant = flightEntity.FuelQuantity,
                Duration = flightEntity.TimeOfFlight,
                Creation = flightEntity.Creation
            };
        }

        public IEnumerable<FlightModel> ConvertToFlightModels(IEnumerable<FlightEntity> flightEntities)
        {
            return flightEntities.Select(f => ConvertToFlightModel(f));
        }
    }
}