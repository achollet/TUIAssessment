using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace TUIAssessment.Web.Controllers
{
    [Route("api/v1/[controller]")]
    public class FlightsReportController : Controller
    {
        private readonly IFlightViewModelBuilder _flightViewModelBuilder;

        [HttpGet("[action]")]
        public IActionResult GetReport()
        {
            var flights = _flightViewModelBuilder.BuildFlightViewModels();

            if (!flights.Any())
                return NotFound();

            return Ok(flights);
        }
    }
}