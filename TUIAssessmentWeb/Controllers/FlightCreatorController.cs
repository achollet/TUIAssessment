using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TUIAssessment.Web.Models;

namespace TUIAssessment.Web.Controllers
{
    [Route("api/[controller]")]
    public class FlightCreatorController : Controller
    {
        [HttpGet("[action]")]
        public IEnumerable<AirportViewModel> GetAirports()
        {
            var airports = new List<AirportViewModel>
            {
                new AirportViewModel("LAX", "Los Angeles International Airport"),
                new AirportViewModel("CDG", "Charles De Gaulles International Airport"),
                new AirportViewModel("JFK", "John Fitzgerald Kennedy International Airport")
            };

            return airports;
        }
    }
}