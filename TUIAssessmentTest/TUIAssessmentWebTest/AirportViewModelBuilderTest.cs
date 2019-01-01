using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TUIAssessmentBusiness.Interfaces;
using System.Collections.Generic;
using TUIAssessmentBusiness.Models;
using TUIAssessmentWeb.Controllers;
using System.Linq;
using TUIAssessment.Web.Models;

namespace TUIAssessmentTest.Builder
{
    [TestClass]
    public class AirportViewModelBuilderTest
    {
        private Mock<IAirportBusiness> _airportBusiness;
        
        [TestInitialize]
        public void Init()
        {
            _airportBusiness = new Mock<IAirportBusiness>();
        }

        [TestMethod]
        public void GivenAnEmptyListOfAirportModel_ShouldReturnEmptyListOfAirportViewModel()
        {
            _airportBusiness.Setup(ab => ab.GetAllAirports()).Returns(new List<AirportModel>());

            var result = new AirportViewModelBuilder(_airportBusiness.Object).BuildAirportList().ToList();

            Assert.IsFalse(result.Any());
        }


        [TestMethod]
        public void GivenListOfOneAirportModel_ShouldReturnListOfOneAirportViewModel()
        {
            _airportBusiness.Setup(ab => ab.GetAllAirports()).Returns(new List<AirportModel>
            {
                new AirportModel{Id = 1, Code = "CDG", Name = "Charles De Gaulle Airport", TakeOffEffort = 900.0, Coordinates = new CoordinatesModel(49.012780, 2.550000)}
            });

            var result = new AirportViewModelBuilder(_airportBusiness.Object).BuildAirportList().ToList();

            Assert.IsTrue(result.Any());
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("CDG", result.First().Code);
            Assert.AreEqual("Charles De Gaulle Airport", result.First().Name);
        }

        [TestMethod]
        public void GivenListOfAirportModel_ShouldReturnListOfAirportViewModel_WithAllAirports()
        {
            _airportBusiness.Setup(ab => ab.GetAllAirports()).Returns(new List<AirportModel>
            {
                new AirportModel{Id = 1, Code = "CDG", Name = "Charles De Gaulle Airport", TakeOffEffort = 900.0, Coordinates = new CoordinatesModel(49.012780, 2.550000)},
                new AirportModel{Id = 2, Code = "JFK", Name = "John Fitzgerald Kennedy Airport", TakeOffEffort = 600.0, Coordinates = new CoordinatesModel(40.6398, -73.7789)},
                new AirportModel{Id = 3, Code = "LAX", Name = "Los Angeles International Airport", TakeOffEffort = 720.0, Coordinates = new CoordinatesModel(34.052230, -118.243680)},
                new AirportModel{Id = 4, Code = "HDN", Name = "Tokyo-Haneda International Airport", TakeOffEffort = 1163.0, Coordinates = new CoordinatesModel(35.552260, 139.779690)},
                new AirportModel{Id = 5, Code = "CPH", Name = "Copenhagen International Airport", TakeOffEffort = 637.0, Coordinates = new CoordinatesModel(55.623564, 12.660777)}
            });

            var expectedAirportViewModels = new List<AirportViewModel>
            {
                new AirportViewModel("CDG", "Charles De Gaulle Airport"),
                new AirportViewModel("JFK","John Fitzgerald Kennedy Airport"),
                new AirportViewModel("LAX", "Los Angeles International Airport"),
                new AirportViewModel("HDN", "Tokyo-Haneda International Airport"),
                new AirportViewModel("CPH", "Copenhagen International Airport")
            };

            var result = new AirportViewModelBuilder(_airportBusiness.Object).BuildAirportList().ToList();

            Assert.IsTrue(result.Any());
            Assert.AreEqual(expectedAirportViewModels.Count, result.Count);
            Assert.IsFalse(result.Any(a => !expectedAirportViewModels.Any(ae => (ae.Name == a.Name && ae.Code == a.Code))));
        }
    }
}