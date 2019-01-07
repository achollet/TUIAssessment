using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TechTalk.SpecFlow;
using TUIAssessmentBusiness;
using TUIAssessmentBusiness.Interfaces;
using TUIAssessmentBusiness.Models;
using TUIAssessmentBusiness.Services;
using TUIAssessmentWeb.Controllers;

namespace TUIAssessmentTest.SpecflowTesting
{
    [Binding]
    public class Binding
    {
        private Mock<IFlightRepository> _flightRepository;
        private Mock<IAirportRepository> _airportRepository;

        #region given assertions
        [Given(@"No flights have been saved in database")]
        public void NoFlightsHaveBeenStoredInDatabase()
        {
            _flightRepository = new Mock<IFlightRepository>();
            _flightRepository.Setup(repo => repo.GetFlights()).Returns(new List<FlightModel>());
        }

        [Given(@"At least one flight has been saved in database")]
        public void AtLeastOneFlightHasBeenStoredInDataBase()
        {
            _flightRepository = new Mock<IFlightRepository>();
            _flightRepository.Setup(repo => repo.GetFlights()).Returns(new List<FlightModel>());
        }

        #endregion

        #region when assertions
        [When(@"I ask for flights report")]
        public void AskForFlightsReport()
        {
            var flightsReportController = GetFlightsReportController();
            var getReportResponse = flightsReportController.GetReport();

            ScenarioContext.Current.Set(getReportResponse, "getReportResponse");
        }

        #endregion

        #region then assertions

        [Then(@"The response code is (.*)")]
        public void ResponseCodeIs(int expectedCode)
        {
            var expectedStatusCode = (HttpStatusCode)expectedCode;

            var httpResponse = ScenarioContext.Current.Get<IActionResult>("getReportResponse");

            httpResponse.Should().NotBeNull();

            var responseStatusCode = CastIActionResultToObjectResult(httpResponse, expectedStatusCode);

            responseStatusCode.StatusCode.Should().Equals(expectedCode);
        }

        #endregion

        #region private method

        private FlightsReportController GetFlightsReportController()
        {
            var flightService = new FlightService();

            var airportBusiness = new AirportBusiness(_airportRepository.Object);
            var flightBusiness = new FlightBusiness(airportBusiness, flightService, _flightRepository.Object);

            var flightViewModelBuilder = new FlightViewModelBuilder(flightBusiness, airportBusiness);

            var flightsReportController = new FlightsReportController(flightViewModelBuilder, flightBusiness);

            return flightsReportController;
        }

        private ObjectResult CastIActionResultToObjectResult(IActionResult httpResponse, HttpStatusCode expectedStatusCode)
        {
            switch (expectedStatusCode)
            {
                case HttpStatusCode.OK:
                    return httpResponse as OkObjectResult;
                case HttpStatusCode.NotFound:
                    return httpResponse as NotFoundObjectResult;
                default:
                    return null;
            }
        }

        #endregion
    }
}