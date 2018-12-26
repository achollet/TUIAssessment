using System;
using System.Collections.Generic;
using System.Linq;
using TUIAssessment.DAL.Entities;

namespace TUIAssessment.DAL
{
    public class TUIAssessmentDAL : ITUIAssessmentDAL
    {
        private readonly TUIAssessmentDALContext _context;

        public TUIAssessmentDAL(TUIAssessmentDALContext context)
        {
            _context = context;
        }

        public bool DeleteFlightEntityByID(int id)
        {
            var flightEntityToDelete = GetFlightEntityByID(id);
            _context.Flights.Remove(flightEntityToDelete);
            return _context.SaveChanges() == 1;
        }

        public IEnumerable<AirportEntity> GetAirportEntities()
        {
            return _context.Airports;
        }

        public AirportEntity GetAirportEntityByID(int id)
        {
            return _context.Airports.First(a => a.Id == id);
        }

        public IEnumerable<FlightEntity> GetFlightEntities()
        {
            return _context.Flights;
        }

        public FlightEntity GetFlightEntityByID(int id)
        {
            return _context.Flights.First(a => a.Id == id);
        }

        public bool SaveFlightEntity(FlightEntity flightEntity)
        {
            flightEntity.Creation = DateTime.UtcNow;
            _context.Flights.Add(flightEntity);
            return _context.SaveChanges() == 1;
        }

        public bool UpdateFlightEntity(FlightEntity flightEntity)
        {
            var flightEntityToUpdate = GetFlightEntityByID(flightEntity.Id);

            flightEntityToUpdate.DepartureAirportId = flightEntity.DepartureAirportId;
            flightEntityToUpdate.ArrivalAirportId = flightEntity.ArrivalAirportId;
            flightEntityToUpdate.Distance = flightEntity.Distance;
            flightEntityToUpdate.FuelQuantity = flightEntity.FuelQuantity;
            flightEntityToUpdate.TimeOfFlight = flightEntity.TimeOfFlight;
            flightEntityToUpdate.Update = DateTime.UtcNow;

            return _context.SaveChanges() == 1;
        }
    }
}