using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TUIAssessment.Web.Models;
using TUIAssessmentBusiness.Interfaces;

namespace TUIAssessment.Web.Controllers
{
    [Route("api/v1/[controller]")]
    public class FlightsReportController : Controller
    {
        private readonly IFlightViewModelBuilder _flightViewModelBuilder;
        private readonly IFlightBusiness _flightBusiness;

        public FlightsReportController(IFlightViewModelBuilder flightViewModelBuilder, IFlightBusiness flightBusiness)
        {
            _flightViewModelBuilder = flightViewModelBuilder;
            _flightBusiness = flightBusiness;
        }

        [HttpGet("[action]")]
        public IActionResult GetReport()
        {
            var flights = _flightViewModelBuilder.BuildFlightViewModels();

            if (!flights.Any())
                return NotFound();

            return Ok(flights);
        }

        [HttpDelete("deleteflight/{id}")]
        public IActionResult DeleteFlight([FromQuery]int id)
        {
            if (id < 1)
                return BadRequest();

            _flightBusiness.DeleteFlightById(id);

            return Ok();
        }

        [HttpPost("updateflight")]
        public IActionResult UpdatedFlight([FromBody]FlightViewModel flightViewModel)
        {
            if (string.IsNullOrWhiteSpace(flightViewModel.ArrivalAirportCode) || string.IsNullOrWhiteSpace(flightViewModel.DepartureAirportCode))
                return BadRequest();

            var flightModel = _flightViewModelBuilder.ConvertFlightViewModelToFlightModel(flightViewModel);

            var updatedFlightModel = _flightBusiness.UpdateFlight(flightModel);

            if (updatedFlightModel == null)
                return NotFound();

            return Ok(updatedFlightModel);
        }
    }
}