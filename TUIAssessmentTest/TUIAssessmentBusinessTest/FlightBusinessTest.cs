using Microsoft.VisualStudio.TestTools.UnitTesting;
using TUIAssessmentBuisness;
using TUIAssessmentBuisness.Services;
using TUIAssessmentBuisness.Models;
using System.Collections.Generic;
using TUIAssessment.DAL.Entities;
using TUIAssessment.DAL;
using Moq;
using System.Linq;

namespace TUIAssessmentTest.Business
{
    [TestClass]
    public class FlightBusinessTest
    {
        private Mock<IAirportBusiness> _airportBusiness;
        private Mock<IFlightService> _flightService;
        private Mock<ITUIAssessmentDAL> _tUIAssessmentDAL;
        private List<AirportModel> _airportsList;
        private List<FlightModel> _expectingFlights;
        private List<FlightEntity> _flightEntities;
        private FlightEntity _flightEntityUpdated;
        private List<AirportEntity> _airportEntities;
        private FlightBusiness _flightBusiness;


        [TestInitialize]
        public void Init()
        {
            _airportBusiness = new Mock<IAirportBusiness>();
            _flightService = new Mock<IFlightService>();
            _tUIAssessmentDAL = new Mock<ITUIAssessmentDAL>();

            _airportsList = new List<AirportModel>
            {
                new AirportModel{Id = 1, Code = "CDG", Name = "Charles De Gaulle Airport", TakeOffEffort = 900.0, Coordinates = new CoordinatesModel(49.012780, 2.550000)},
                new AirportModel{Id = 2, Code = "JFK", Name = "John Fitzgerald Kennedy Airport", TakeOffEffort = 600.0, Coordinates = new CoordinatesModel(40.6398, -73.7789)},
                new AirportModel{Id = 3, Code = "LAX", Name = "Los Angeles International Airport", TakeOffEffort = 720.0, Coordinates = new CoordinatesModel(34.052230, -118.243680)},
                new AirportModel{Id = 4, Code = "HDN", Name = "Tokyo-Haneda International Airport", TakeOffEffort = 1163.0, Coordinates = new CoordinatesModel(35.552260, 139.779690)},
                new AirportModel{Id = 5, Code = "CPH", Name = "Copenhagen International Airport", TakeOffEffort = 637.0, Coordinates = new CoordinatesModel(55.623564, 12.660777)}
            };

            _expectingFlights = new List<FlightModel>
            {
                new FlightModel{ ID = 1, DepartureAirport = _airportsList[0], ArrivalAirport = _airportsList[1], Distance = 6666.66, Carburant = 42.0, Duration = 12.0},
                new FlightModel{ ID = 2, DepartureAirport = _airportsList[1], ArrivalAirport = _airportsList[2], Distance = 6666.66, Carburant = 42.0, Duration = 12.0},
                new FlightModel{ ID = 3, DepartureAirport = _airportsList[3], ArrivalAirport = _airportsList[4], Distance = 6666.66, Carburant = 42.0, Duration = 12.0},
                new FlightModel{ ID = 4, DepartureAirport = _airportsList[1], ArrivalAirport = _airportsList[4], Distance = 6666.66, Carburant = 42.0, Duration = 12.0},
                new FlightModel{ ID = 5, DepartureAirport = _airportsList[0], ArrivalAirport = _airportsList[3], Distance = 6666.66, Carburant = 42.0, Duration = 12.0}
            };

            _airportEntities = new List<AirportEntity>
            {
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
            };

            _flightEntities = new List<FlightEntity>
            {
                new FlightEntity{ Id = 1, DepartureAirportId = 1, ArrivalAirportId = 2, Distance = 6666.66, FuelQuantity = 42.0, TimeOfFlight = 12.0},
                new FlightEntity{ Id = 2, DepartureAirportId = 2, ArrivalAirportId = 3, Distance = 6666.66, FuelQuantity = 42.0, TimeOfFlight = 12.0},
                new FlightEntity{ Id = 3, DepartureAirportId = 4, ArrivalAirportId = 5, Distance = 6666.66, FuelQuantity = 42.0, TimeOfFlight = 12.0},
                new FlightEntity{ Id = 4, DepartureAirportId = 2, ArrivalAirportId = 5, Distance = 6666.66, FuelQuantity = 42.0, TimeOfFlight = 12.0},
                new FlightEntity{ Id = 5, DepartureAirportId = 1, ArrivalAirportId = 4, Distance = 6666.66, FuelQuantity = 42.0, TimeOfFlight = 12.0}
            };

            _flightEntityUpdated = new FlightEntity { Id = 1, DepartureAirportId = 1, ArrivalAirportId = 2, Distance = 4206.66, FuelQuantity = 42.0, TimeOfFlight = 12.0 };

            #region mocks setup

            _airportBusiness.Setup(ab => ab.GetAirportById(1)).Returns(_airportsList[0]);
            _airportBusiness.Setup(ab => ab.GetAirportById(2)).Returns(_airportsList[1]);
            _airportBusiness.Setup(ab => ab.GetAirportById(3)).Returns(_airportsList[2]);
            _airportBusiness.Setup(ab => ab.GetAirportById(4)).Returns(_airportsList[3]);
            _airportBusiness.Setup(ab => ab.GetAirportById(5)).Returns(_airportsList[4]);

            _flightService.Setup(fs => fs.CalculateDistanceWithHaversineFormulae(It.IsAny<CoordinatesModel>(), It.IsAny<CoordinatesModel>())).Returns(6666.66);
            _flightService.Setup(fs => fs.CalculateFuelVolumeForFlight(It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>())).Returns(42.0);
            _flightService.Setup(fs => fs.CalculateTimeOfFlight(It.IsAny<double>(), It.IsAny<double>())).Returns(12.0);

            _tUIAssessmentDAL.Setup(dal => dal.SaveFlightEntity(It.IsAny<FlightEntity>())).Returns(new FlightEntity());
            _tUIAssessmentDAL.Setup(dal => dal.GetAirportEntities()).Returns(_airportEntities);
            _tUIAssessmentDAL.Setup(dal => dal.GetFlightEntities()).Returns(_flightEntities);
            _tUIAssessmentDAL.Setup(dal => dal.UpdateFlightEntity(It.IsAny<FlightEntity>())).Returns(_flightEntityUpdated);
            _tUIAssessmentDAL.Setup(dal => dal.RemoveFlightEntityByID(It.IsAny<int>())).Returns(true);

            #endregion

            _flightBusiness = new FlightBusiness(_airportBusiness.Object, _flightService.Object, _tUIAssessmentDAL.Object);
        }

        [DataTestMethod]
        [DataRow(1, 2, 1)]
        [DataRow(2, 3, 2)]
        [DataRow(4, 5, 3)]
        [DataRow(2, 5, 4)]
        [DataRow(1, 4, 5)]
        public void FlightBusiness_CreateFlightMethod_Test(int departureAirportId, int arrivalAirportId, int expectingFlightId)
        {
            var resultingFlight = _flightBusiness.CreateFlight(departureAirportId, arrivalAirportId);
            var expectingFlight = _expectingFlights.First(f => f.ID == expectingFlightId);

            #region  testing method's calls

            _flightService.Verify(fs => fs.CalculateDistanceWithHaversineFormulae(It.IsAny<CoordinatesModel>(), It.IsAny<CoordinatesModel>()), Times.Once);
            _flightService.Verify(fs => fs.CalculateDistanceWithVicentyFormulae(It.IsAny<CoordinatesModel>(), It.IsAny<CoordinatesModel>()), Times.Never);
            _flightService.Verify(fs => fs.CalculateFuelVolumeForFlight(It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>()), Times.Once);
            _flightService.Verify(fs => fs.CalculateTimeOfFlight(It.IsAny<double>(), It.IsAny<double>()), Times.Once);

            _tUIAssessmentDAL.Verify(dal => dal.SaveFlightEntity(It.IsAny<FlightEntity>()), Times.Once);

            _airportBusiness.Verify(ab => ab.GetAirportById(It.IsAny<int>()), Times.AtLeastOnce());
            #endregion

            #region testing resulting flight

            Assert.IsNotNull(resultingFlight);
            Assert.AreEqual(expectingFlight.Distance, resultingFlight.Distance);
            Assert.AreEqual(expectingFlight.Duration, resultingFlight.Duration);
            Assert.AreEqual(expectingFlight.Carburant, resultingFlight.Carburant);

            Assert.IsNotNull(resultingFlight.DepartureAirport);
            Assert.AreEqual(expectingFlight.DepartureAirport.Id, resultingFlight.DepartureAirport.Id);
            Assert.IsNotNull(resultingFlight.ArrivalAirport);
            Assert.AreEqual(expectingFlight.ArrivalAirport.Id, resultingFlight.ArrivalAirport.Id);

            #endregion
        }

        [TestMethod]
        public void FlightBusiness_GetAllFlights_Test()
        {
            var resultingFlights = _flightBusiness.GetAllFlights();

            Assert.IsNotNull(resultingFlights);
            Assert.IsTrue(resultingFlights.Any());

            foreach (var resultingFlight in resultingFlights)
            {
                var expectedFlight = _expectingFlights.FirstOrDefault(f => f.ID == resultingFlight.ID);
                Assert.IsNotNull(expectedFlight);
                Assert.AreEqual(expectedFlight.Distance, resultingFlight.Distance);
                Assert.AreEqual(expectedFlight.Duration, resultingFlight.Duration);
                Assert.AreEqual(expectedFlight.Carburant, resultingFlight.Carburant);

                Assert.IsNotNull(resultingFlight.DepartureAirport);
                Assert.AreEqual(expectedFlight.DepartureAirport.Id, resultingFlight.DepartureAirport.Id);
                Assert.IsNotNull(resultingFlight.ArrivalAirport);
                Assert.AreEqual(expectedFlight.ArrivalAirport.Id, resultingFlight.ArrivalAirport.Id);
            }
        }

        [TestMethod]
        public void FlightBusiness_UpdateFlight_Test()
        {
            var flightToUpdate = new FlightModel
            {
                ID = 1,
                DepartureAirport = _airportsList[0],
                ArrivalAirport = _airportsList[1],
                Distance = 4206.66,
                Carburant = 42.0,
                Duration = 12.0
            };

            var updatedFlightResult = _flightBusiness.UpdateFlight(flightToUpdate);

            Assert.IsNotNull(updatedFlightResult);
            Assert.AreEqual(updatedFlightResult.ID, flightToUpdate.ID);
            Assert.AreEqual(updatedFlightResult.Distance, flightToUpdate.Distance);
        }

        [TestMethod]
        public void FlightBusiness_RemoveFlight_Test()
        {
            var flightIdToRemove = 1;

            var hasBeenRemoved = _flightBusiness.DeleteFlightById(flightIdToRemove);

            Assert.IsTrue(hasBeenRemoved);
        }
    }
}