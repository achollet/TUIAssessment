using Microsoft.VisualStudio.TestTools.UnitTesting;
using TUIAssessmentBuisness;
using TUIAssessmentBuisness.Services;
using TUIAssessmentBuisness.Models;
using System.Collections.Generic;
using Moq;

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
                new AirportModel{Id = 1, Code = "CDG", Name = "Charles De Gaulle", TakeOffEffort = 900.0}
            };

            _flightBusiness = new FlightBusiness(_airportBusiness.Object, _flightService.Object);
        }

        [DataTestMethod]
        [DataRow(1, 2)]
        public void FlightBusiness_CreateFlight(int departureAirportId, int arrivalAirportId)
        {
            var resultingFlight = _flightBusiness.CreateFlight(departureAirportId, arrivalAirportId);
            
            #region  testing method's calls

            _flightService.Verify(fs => fs.CalculateDistanceWithHaversineFormulae(It.IsAny<CoordinatesModel>(), It.IsAny<CoordinatesModel>()), Times.Once);
            _flightService.Verify(fs => fs.CalculateDistanceWithVicentyFormulae(It.IsAny<CoordinatesModel>(), It.IsAny<CoordinatesModel>()), Times.Never);
            _flightService.Verify(fs => fs.CalculateFuelVolumeForFlight(It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>()), Times.Once);
            _flightService.Verify(fs => fs.CalculateTimeOfFlight(It.IsAny<double>(), It.IsAny<double>()), Times.Once);

            _airportBusiness.Verify(ab => ab.GetAirportById(It.IsAny<int>()), Times.AtLeastOnce());
            #endregion

            #region testing resulting flight

            Assert.IsNotNull(resultingFlight);

            #endregion
        }
    }
}