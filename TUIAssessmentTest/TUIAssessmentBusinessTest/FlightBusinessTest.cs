using Microsoft.VisualStudio.TestTools.UnitTesting;
using TUIAssessmentBuisness;
using TUIAssessmentBuisness.Services;
using TUIAssessmentBuisness.Models;
using System.Collections.Generic;
using Moq;
using System.Linq; 

namespace TUIAssessmentTest.Business
{
    [TestClass]
    public class FlightBusinessTest
    {
        private Mock<IAirportBusiness> _airportBusiness;
        private Mock<IFlightService> _flightService;
        private List<AirportModel> _airportsList;
        private List<FlightModel> _expectingFlights;
        private FlightBusiness _flightBusiness;

        [TestInitialize]
        public void Init()
        {
            _airportBusiness = new Mock<IAirportBusiness>();
            _flightService = new Mock<IFlightService>();

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

            #region mocks setup

            _airportBusiness.Setup(ab => ab.GetAirportById(1)).Returns(_airportsList[0]);
            _airportBusiness.Setup(ab => ab.GetAirportById(2)).Returns(_airportsList[1]);
            _airportBusiness.Setup(ab => ab.GetAirportById(3)).Returns(_airportsList[2]);
            _airportBusiness.Setup(ab => ab.GetAirportById(4)).Returns(_airportsList[3]);
            _airportBusiness.Setup(ab => ab.GetAirportById(5)).Returns(_airportsList[4]);

            _flightService.Setup(fs => fs.CalculateDistanceWithHaversineFormulae(It.IsAny<CoordinatesModel>(), It.IsAny<CoordinatesModel>())).Returns(6666.66);
            _flightService.Setup(fs => fs.CalculateFuelVolumeForFlight(It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>())).Returns(42.0);
            _flightService.Setup(fs => fs.CalculateTimeOfFlight(It.IsAny<double>(), It.IsAny<double>())).Returns(12.0);

            #endregion

            _flightBusiness = new FlightBusiness(_airportBusiness.Object, _flightService.Object);
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

            _airportBusiness.Verify(ab => ab.GetAirportById(It.IsAny<int>()), Times.AtLeastOnce());
            #endregion

            #region testing resulting flight

            Assert.IsNotNull(resultingFlight);
            //Assert.AreEqual(expectingFlight.ID, resultingFlight.ID);
            Assert.AreEqual(expectingFlight.Distance, resultingFlight.Distance);
            Assert.AreEqual(expectingFlight.Duration, resultingFlight.Duration);
            Assert.AreEqual(expectingFlight.Carburant, resultingFlight.Carburant);

            Assert.IsNotNull(resultingFlight.DepartureAirport);
            Assert.AreEqual(expectingFlight.DepartureAirport.Id, resultingFlight.DepartureAirport.Id);
            Assert.IsNotNull(resultingFlight.ArrivalAirport);
            Assert.AreEqual(expectingFlight.ArrivalAirport.Id, resultingFlight.ArrivalAirport.Id);

            #endregion
        }
    }
}