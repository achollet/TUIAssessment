using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TUIAssessment.Web.Models;

namespace TUIAssessment.Web.Controllers
{
    [Route("api/[controller]")]
    public class FlightsReportController : Controller
    {
        [HttpGet("[action]")]
        public IEnumerable<Flight> GetReport()
        {
            var flights = new List<Flight>
            {
                new Flight {Id = 1, DepartureAirportCode = "CDG", ArrivalAirportCode = "LAX", Distance= 9086.71m, TimeOfFlight = "11:14:00", CreationDate = DateTime.Now },
                new Flight {Id = 2, DepartureAirportCode = "CDG", ArrivalAirportCode = "JFK", Distance= 5849m, TimeOfFlight = "7:22:00", CreationDate = DateTime.Now.AddDays(-2), UpdateDate = DateTime.Now },
                new Flight {Id = 3, DepartureAirportCode = "LAX", ArrivalAirportCode = "JFK", Distance= 3982.94m, TimeOfFlight = "5:11:00", CreationDate = DateTime.Now },
                new Flight {Id = 4, DepartureAirportCode = "JFK", ArrivalAirportCode = "LAX", Distance= 3982.94m, TimeOfFlight = "5:11:00", CreationDate = DateTime.Now },
            };

            return flights;
        }
    }
}
