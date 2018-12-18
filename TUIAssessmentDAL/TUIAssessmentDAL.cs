using System.Collections.Generic;
using TUIAssessment.DAL.Entities;
using TUIAssessment.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using Microsoft.Extensions.Options;

namespace TUIAssessment.DAL
{
    public class TUIAssessmentDAL : ITUIAssessmentDAL
    {
        private readonly string _connectionString = "Data Source=tuiassessment.db";
        private DbContextOptions _options;

        public TUIAssessmentDAL()
        {
            _options = GetDbContextOptions();
        }

        #region reading methods

        public AirportEntity GetAirportEntityByID(int Id)
        {
            AirportEntity airport = null;

            using (var context = new TUIAssessmentDALContext(_options))
            {
                airport = context.Airports.Single(a => a.Id == Id);
            }

            return airport;
        }

        public IEnumerable<AirportEntity> GetAirportEntities()
        {
            var airports = new List<AirportEntity>();

            using (var context = new TUIAssessmentDALContext(_options))
            {
                airports = context.Airports.ToList();
            }

            return airports;
        }

        public FlightEntity GetFlightEntityByID(int Id)
        {
            FlightEntity flight = null;

            using (var context = new TUIAssessmentDALContext(_options))
            {
                flight = context.Flights.Single(f => f.Id == Id);
            }

            return flight;
        }

        public IEnumerable<FlightEntity> GetFlightEntities()
        {
            var flights = new List<FlightEntity>();

            using (var context = new TUIAssessmentDALContext(_options))
            {
                flights = context.Flights.ToList();
            }

            return flights;
        }

        #endregion

        #region writing methods

        public FlightEntity UpdateFlightEntity(FlightEntity flight)
        {
            using (var context = new TUIAssessmentDALContext(_options))
            {
                var flightInDB = context.Flights.Single(f => f.Id == flight.Id);

                if (flightInDB != null)
                {
                    flightInDB.ArrivalAirportId = flight.ArrivalAirportId;
                    flightInDB.DepartureAirportId = flight.DepartureAirportId;
                    flightInDB.Distance = flight.Distance;
                    flightInDB.FuelQuantity = flight.FuelQuantity;
                    flightInDB.TimeOfFlight = flight.TimeOfFlight;
                    flightInDB.Update = DateTime.Now;
                }

                context.SaveChanges();
            }

            return GetFlightEntityByID(flight.Id);
        }

        public FlightEntity SaveFlightEntity(FlightEntity flight)
        {
            using (var context = new TUIAssessmentDALContext(_options))
            {
                context.Flights.Add(flight);
                context.SaveChanges();
            }

            return flight;
        }

        public bool RemoveFlightEntityByID(int Id)
        {
            var count = 0;
            using (var context = new TUIAssessmentDALContext(_options))
            {
                var flight = context.Flights.Single(f => f.Id == Id);
                if (flight != null)
                {
                    context.Flights.Remove(flight);
                    count = context.SaveChanges();
                }
            }

            return count == 1;
        }

        #endregion

        private DbContextOptions GetDbContextOptions()
        {
            var optionsBuilder = new DbContextOptionsBuilder<TUIAssessmentDALContext>();
            return optionsBuilder.UseSqlite(_connectionString).Options;
        }
    }
}