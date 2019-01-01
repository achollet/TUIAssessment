using Microsoft.VisualStudio.TestTools.UnitTesting;
using TUIAssessmentBusiness.Services;
using TUIAssessmentBusiness.Interfaces;
using TUIAssessmentBusiness.Models;
using System.Collections.Generic;
using Moq;
using System.Linq;
using TUIAssessmentBusiness;

namespace TUIAssessmentTest.Business
{
    [TestClass]
    public class FlightBusinessTest
    {
        private Mock<IAirportBusiness> _airportBusiness;
        private Mock<IFlightService> _flightService;
        private Mock<IFlightRepository> _flightRepository;
        private Mock<IAirportRepository> _airportRepository;
        private List<AirportModel> _airportsList;
        private List<FlightModel> _expectingFlights;
        private List<FlightModel> _flightModels;
        private FlightModel _flightModelUpdated;
        private List<AirportModel> _airportModels;
        private FlightBusiness _flightBusiness;


        [TestInitialize]
        public void Init()
        {
            _airportBusiness = new Mock<IAirportBusiness>();
            _flightService = new Mock<IFlightService>();
            _flightRepository = new Mock<IFlightRepository>();

            //_airportsList = new List<AirportModel>
            //{
            //    new AirportModel{Id = 1, Code = "CDG", Name = "Charles De Gaulle Airport", TakeOffEffort = 900.0, Coordinates = new CoordinatesModel(49.012780, 2.550000)},
            //    new AirportModel{Id = 2, Code = "JFK", Name = "John Fitzgerald Kennedy Airport", TakeOffEffort = 600.0, Coordinates = new CoordinatesModel(40.6398, -73.7789)},
            //    new AirportModel{Id = 3, Code = "LAX", Name = "Los Angeles International Airport", TakeOffEffort = 720.0, Coordinates = new CoordinatesModel(34.052230, -118.243680)},
            //    new AirportModel{Id = 4, Code = "HDN", Name = "Tokyo-Haneda International Airport", TakeOffEffort = 1163.0, Coordinates = new CoordinatesModel(35.552260, 139.779690)},
            //    new AirportModel{Id = 5, Code = "CPH", Name = "Copenhagen International Airport", TakeOffEffort = 637.0, Coordinates = new CoordinatesModel(55.623564, 12.660777)}
            //};

            _expectingFlights = new List<FlightModel>
            {
                new FlightModel{ ID = 1, DepartureAirport = _airportsList[0], ArrivalAirport = _airportsList[1], Distance = 6666.66, Carburant = 42.0, Duration = 12.0},
                new FlightModel{ ID = 2, DepartureAirport = _airportsList[1], ArrivalAirport = _airportsList[2], Distance = 6666.66, Carburant = 42.0, Duration = 12.0},
                new FlightModel{ ID = 3, DepartureAirport = _airportsList[3], ArrivalAirport = _airportsList[4], Distance = 6666.66, Carburant = 42.0, Duration = 12.0},
                new FlightModel{ ID = 4, DepartureAirport = _airportsList[1], ArrivalAirport = _airportsList[4], Distance = 6666.66, Carburant = 42.0, Duration = 12.0},
                new FlightModel{ ID = 5, DepartureAirport = _airportsList[0], ArrivalAirport = _airportsList[3], Distance = 6666.66, Carburant = 42.0, Duration = 12.0}
            };

            _airportsList = new List<AirportModel>
            {
                new AirportModel { Id = 1, Code = "CDG", Name = "Paris-Charles De Gaulle", Coordinates = new CoordinatesModel(49.009642, 2.547885 )},
                new AirportModel { Id = 2, Code = "MXP", Name = "Milan-Malpensa", Coordinates = new CoordinatesModel( 45.629646, 8.724174 )},
                new AirportModel { Id = 3, Code = "LHR", Name = "London-Heathrow", Coordinates = new CoordinatesModel( 51.472401, -0.467262 )},
                new AirportModel { Id = 4, Code = "AMS", Name = "Amsterdam-Schipol", Coordinates = new CoordinatesModel( 52.31488, 4.757767 )},
                new AirportModel { Id = 5, Code = "FRA", Name = "Frankfurt-Airport", Coordinates = new CoordinatesModel( 50.035313, 8.559723 )},
                new AirportModel { Id = 6, Code = "JFK", Name = "New-York-John F. Kennedy", Coordinates = new CoordinatesModel( 40.64444, -73.778 )},
                new AirportModel { Id = 7, Code = "LAX", Name = "Los Angeles International Airport", Coordinates = new CoordinatesModel( 33.941154, -118.409447 )},
                new AirportModel { Id = 8, Code = "ATL", Name = "Atlanta-Hartsfield-Jackson", Coordinates = new CoordinatesModel( 33.635899, -84.428719 )},
                new AirportModel { Id = 9, Code = "YUL", Name = "Montreal-Trudeau", Coordinates = new CoordinatesModel( 45.470604, -73.744354 )},
                new AirportModel { Id = 10, Code = "YVR", Name = "Vancouver Airport", Coordinates = new CoordinatesModel( 49.192398, -123.179596 )},
                new AirportModel { Id = 11, Code = "EZE", Name = "Buenos Aires-Pistarini", Coordinates = new CoordinatesModel( -34.812111, -58.539619 )},
                new AirportModel { Id = 12, Code = "SJO", Name = "San Jose Airport", Coordinates = new CoordinatesModel( 9.957228, -84.139236 )},
                new AirportModel { Id = 13, Code = "GIG", Name = "Rio De Janeiro International Airport", Coordinates = new CoordinatesModel( -22.910809, -43.163223 )},
                new AirportModel { Id = 14, Code = "RUH", Name = "Riyad King Kahild International Airport", Coordinates = new CoordinatesModel( 24.954332, 46.700993 )},
                new AirportModel { Id = 15, Code = "DOH", Name = "Doha International Airport", Coordinates = new CoordinatesModel( 25.261309, 51.562614 )},
                new AirportModel { Id = 16, Code = "PVG", Name = "Shanghai Pudong International Airport", Coordinates = new CoordinatesModel( 31.144997, 121.811371 )},
                new AirportModel { Id = 17, Code = "ICN", Name = "Seoul Incheon Airport", Coordinates = new CoordinatesModel( 37.471603, 126.455666 )},
                new AirportModel { Id = 18, Code = "HND", Name = "Tokyo Haneda Airport", Coordinates = new CoordinatesModel( 35.554993, 139.780258 )},
                new AirportModel { Id = 19, Code = "SYD", Name = "Sydney Airport", Coordinates = new CoordinatesModel( -33.94997, 151.178482 )},
                new AirportModel { Id = 20, Code = "JNB", Name = "Johanesburg- OR Tambo International Airport", Coordinates = new CoordinatesModel( -26.123140, 28.243365 )}
            };

            // _flightEntities = new List<FlightEntity>
            // {
            //     new FlightEntity{ Id = 1, DepartureAirportId = 1, ArrivalAirportId = 2, Distance = 6666.66, FuelQuantity = 42.0, TimeOfFlight = 12.0},
            //     new FlightEntity{ Id = 2, DepartureAirportId = 2, ArrivalAirportId = 3, Distance = 6666.66, FuelQuantity = 42.0, TimeOfFlight = 12.0},
            //     new FlightEntity{ Id = 3, DepartureAirportId = 4, ArrivalAirportId = 5, Distance = 6666.66, FuelQuantity = 42.0, TimeOfFlight = 12.0},
            //     new FlightEntity{ Id = 4, DepartureAirportId = 2, ArrivalAirportId = 5, Distance = 6666.66, FuelQuantity = 42.0, TimeOfFlight = 12.0},
            //     new FlightEntity{ Id = 5, DepartureAirportId = 1, ArrivalAirportId = 4, Distance = 6666.66, FuelQuantity = 42.0, TimeOfFlight = 12.0}
            // };

             _flightModelUpdated = new FlightModel { ID = 1, DepartureAirport = _airportModels[1], ArrivalAirport= _airportModels[2], Distance = 4206.66, Carburant = 42.0, Duration = 12.0 };

            #region mocks setup

            _airportBusiness.Setup(ab => ab.GetAirportById(1)).Returns(_airportsList[0]);
            _airportBusiness.Setup(ab => ab.GetAirportById(2)).Returns(_airportsList[1]);
            _airportBusiness.Setup(ab => ab.GetAirportById(3)).Returns(_airportsList[2]);
            _airportBusiness.Setup(ab => ab.GetAirportById(4)).Returns(_airportsList[3]);
            _airportBusiness.Setup(ab => ab.GetAirportById(5)).Returns(_airportsList[4]);
            _airportBusiness.Setup(ab => ab.GetAllAirports()).Returns(_airportModels);

            _flightService.Setup(fs => fs.CalculateDistanceWithHaversineFormulae(It.IsAny<CoordinatesModel>(), It.IsAny<CoordinatesModel>())).Returns(6666.66);
            _flightService.Setup(fs => fs.CalculateFuelVolumeForFlight(It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>())).Returns(42.0);
            _flightService.Setup(fs => fs.CalculateTimeOfFlight(It.IsAny<double>(), It.IsAny<double>())).Returns(12.0);

            _flightRepository.Setup(repo => repo.SaveFlight(It.IsAny<FlightModel>())).Returns(true);
            _flightRepository.Setup(repo => repo.GetFlights()).Returns(_flightModels);
            _flightRepository.Setup(repo => repo.UpdateFlight(It.IsAny<FlightModel>())).Returns(_flightModelUpdated);
            _flightRepository.Setup(repo => repo.RemoveFlightByID(It.IsAny<int>())).Returns(true);

            #endregion

            _flightBusiness = new FlightBusiness(_airportBusiness.Object, _flightService.Object, _flightRepository.Object);
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

            _flightRepository.Verify(repo => repo.SaveFlight(It.IsAny<FlightModel>()), Times.Once);

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