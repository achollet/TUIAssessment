using Moq;
using System.Collections.Generic;
using TUIAssessmentBusiness.Models;
using TUIAssessmentBusiness.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TUIAssessmentBusiness;
using FluentAssertions;

namespace TUIAssessmentTest.Business
{
    [TestClass]
    public class AirportBusinessTest
    {
        private Mock<IAirportRepository> _airportRepository;
        private IEnumerable<AirportModel> _airportModels;

        private AirportBusiness _airportBusiness;

        [TestInitialize]
        public void Init()
        {
            _airportRepository = new Mock<IAirportRepository>();

            _airportModels = new List<AirportModel>
            {
                new AirportModel{Id = 1, Code = "CDG", Name = "Charles De Gaulle Airport", TakeOffEffort = 900.0, Coordinates = new CoordinatesModel(49.012780, 2.550000)},
                new AirportModel{Id = 2, Code = "JFK", Name = "John Fitzgerald Kennedy Airport", TakeOffEffort = 600.0, Coordinates = new CoordinatesModel(40.6398, -73.7789)},
                new AirportModel{Id = 3, Code = "LAX", Name = "Los Angeles International Airport", TakeOffEffort = 720.0, Coordinates = new CoordinatesModel(34.052230, -118.243680)},
                new AirportModel{Id = 4, Code = "HDN", Name = "Tokyo-Haneda International Airport", TakeOffEffort = 1163.0, Coordinates = new CoordinatesModel(35.552260, 139.779690)},
                new AirportModel{Id = 5, Code = "CPH", Name = "Copenhagen International Airport", TakeOffEffort = 637.0, Coordinates = new CoordinatesModel(55.623564, 12.660777)}
            };

            _airportRepository.Setup(ar => ar.GetAirportModelByID(1)).Returns(_airportModels.First(am => am.Id == 1));

            _airportBusiness = new AirportBusiness(_airportRepository.Object);
        }

        [TestMethod]
        public void GetAirportModelByID_AirportIdExist_ShouldReturnAirportModel()
        {
            var airportId = 1;

            var expectedAirportModel = _airportModels.First(am => am.Id == airportId);

            var result = _airportBusiness.GetAirportById(airportId);

            _airportRepository.Verify(ar => ar.GetAirportModelByID(airportId), Times.Once);

            result.Should().NotBeNull();
            result.Id.Should().Equals(expectedAirportModel.Id);
            result.Code.Should().Equals(expectedAirportModel.Code);
            result.Name.Should().Equals(expectedAirportModel.Name);
            result.TakeOffEffort.Should().Equals(expectedAirportModel.TakeOffEffort);
        }

        [TestMethod]
        public void GetAirportModelByID_AirportIdNotExist_ShouldReturnNull()
        {
            var airportId = 6;

            var result = _airportBusiness.GetAirportById(airportId);
            _airportRepository.Verify(ar => ar.GetAirportModelByID(airportId), Times.Once);
            result.Should().BeNull();
        }

        [TestMethod]
        public void GetAllAirports_ShouldReturnAirportModels()
        {
            _airportRepository.Setup(ar => ar.GetAirportModels()).Returns(_airportModels);

            var result = _airportBusiness.GetAllAirports();

            _airportRepository.Verify(ar => ar.GetAirportModels(), Times.Once);

            result.Should().NotBeEmpty()
                           .And.HaveCount(_airportModels.Count())
                           .And.OnlyHaveUniqueItems()
                           .And.Contain(_airportModels);

        }
    }
}