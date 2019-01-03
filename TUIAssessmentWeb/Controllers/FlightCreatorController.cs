using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TUIAssessmentBusiness.Interfaces;

namespace TUIAssessment.Web.Controllers
{
    [Route("api/v1/[controller]")]
    public class FlightCreatorController : Controller
    {
        private readonly IAirportViewModelBuilder _airportViewModelBuilder;
        private readonly IFlightViewModelBuilder _flightViewModelBuilder;
        private readonly IFlightBusiness _flightBusiness;

        public FlightCreatorController(IAirportViewModelBuilder airportViewModelBuilder,
                                       IFlightViewModelBuilder flightViewModelBuilder,
                                       IFlightBusiness flightBusiness)
        {
            _airportViewModelBuilder = airportViewModelBuilder;
            _flightViewModelBuilder = flightViewModelBuilder;
            _flightBusiness = flightBusiness;
        }

        [HttpGet("getairports")]
        public IActionResult GetAirports()
        {
            var airportViewModels = _airportViewModelBuilder.BuildAirportList();

            if (!airportViewModels.Any())
                return NotFound();

            return Ok(airportViewModels);
        }

        [HttpPost("createflight")]
        public IActionResult CreateFlight([FromBody]int departureAirportId, [FromBody]int arrivalAirportId)
        {
            if (departureAirportId < 1 || arrivalAirportId < 1)
                return BadRequest();

            var flightModel = _flightBusiness.CreateFlight(departureAirportId, arrivalAirportId);

            if (flightModel == null)
                return StatusCode(500);

            var flightViewModel = _flightViewModelBuilder.Build(flightModel);

            return StatusCode(201, flightViewModel);
        }
    }
}