using Microsoft.EntityFrameworkCore;
using TUIAssessment.DAL.Entities;

namespace TUIAssessment.DAL
{
    public class TUIAssessmentDALContext : DbContext
    {
        public DbSet<AirportEntity> Airports { get; set; }
        public DbSet<FlightEntity> Flights { get; set; }

        public TUIAssessmentDALContext(DbContextOptions options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AirportEntity>().HasIndex(a => a.Id).HasName("IDX_Airport_Id");
            modelBuilder.Entity<AirportEntity>().HasIndex(a => a.Code).HasName("IDX_Airport_Code");

            modelBuilder.Entity<FlightEntity>().HasIndex(f => f.Id).HasName("IDX_Flight_ID");
            modelBuilder.Entity<FlightEntity>().HasIndex(f => new { f.DepartureAirportId, f.ArrivalAirportId }).HasName("IDX_Flight_Departure_Arrival");

            #region airports table seed

            modelBuilder.Entity<AirportEntity>().HasData(
                new AirportEntity { Id = 1, Code = "CDG", Name = "Paris-Charles De Gaulle", Latitude = 49.009642, Longitude = 2.547885 },
                new AirportEntity { Id = 2, Code = "MXP", Name = "Milan-Malpensa", Latitude = 45.629646, Longitude = 8.724174 },
                new AirportEntity { Id = 3, Code = "LHR", Name = "London-Heathrow", Latitude = 51.472401, Longitude = -0.467262 },
                new AirportEntity { Id = 4, Code = "AMS", Name = "Amsterdam-Schipol", Latitude = 52.31488, Longitude = 4.757767 },
                new AirportEntity { Id = 5, Code = "FRA", Name = "Frankfurt-Airport", Latitude = 50.035313, Longitude = 8.559723 },
                new AirportEntity { Id = 6, Code = "JFK", Name = "New-York-John F. Kennedy", Latitude = 40.64444, Longitude = -73.778 },
                new AirportEntity { Id = 7, Code = "LAX", Name = "Los Angeles International Airport", Latitude = 33.941154, Longitude = -118.409447 },
                new AirportEntity { Id = 8, Code = "ATL", Name = "Atlanta-Hartsfield-Jackson", Latitude = 33.635899, Longitude = -84.428719 },
                new AirportEntity { Id = 9, Code = "YUL", Name = "Montreal-Trudeau", Latitude = 45.470604, Longitude = -73.744354 },
                new AirportEntity { Id = 10, Code = "YVR", Name = "Vancouver Airport", Latitude = 49.192398, Longitude = -123.179596 },
                new AirportEntity { Id = 11, Code = "EZE", Name = "Buenos Aires-Pistarini", Latitude = -34.812111, Longitude = -58.539619 },
                new AirportEntity { Id = 12, Code = "SJO", Name = "San Jose Airport", Latitude = 9.957228, Longitude = -84.139236 },
                new AirportEntity { Id = 13, Code = "GIG", Name = "Rio De Janeiro International Airport", Latitude = -22.910809, Longitude = -43.163223 },
                new AirportEntity { Id = 14, Code = "RUH", Name = "Riyad King Kahild International Airport", Latitude = 24.954332, Longitude = 46.700993 },
                new AirportEntity { Id = 15, Code = "DOH", Name = "Doha International Airport", Latitude = 25.261309, Longitude = 51.562614 },
                new AirportEntity { Id = 16, Code = "PVG", Name = "Shanghai Pudong International Airport", Latitude = 31.144997, Longitude = 121.811371 },
                new AirportEntity { Id = 17, Code = "ICN", Name = "Seoul Incheon Airport", Latitude = 37.471603, Longitude = 126.455666 },
                new AirportEntity { Id = 18, Code = "HND", Name = "Tokyo Haneda Airport", Latitude = 35.554993, Longitude = 139.780258 },
                new AirportEntity { Id = 19, Code = "SYD", Name = "Sydney Airport", Latitude = -33.94997, Longitude = 151.178482 },
                new AirportEntity { Id = 20, Code = "JNB", Name = "Johanesburg- OR Tambo International Airport", Latitude = -26.123140, Longitude = 28.243365 }
            );

            #endregion
        }
    }
}