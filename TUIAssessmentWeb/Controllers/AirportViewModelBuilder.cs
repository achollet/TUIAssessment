using System.Collections.Generic;
using System.Linq;
using TUIAssessment.Web.Controllers;
using TUIAssessment.Web.Models;
using TUIAssessmentBusiness.Interfaces;
using TUIAssessmentBusiness.Models;

namespace TUIAssessmentWeb.Controllers
{
    public class AirportViewModelBuilder : IAirportViewModelBuilder
    {
        private readonly IAirportBusiness _airportBusiness;

        public AirportViewModelBuilder(IAirportBusiness airportBusiness)
        {
            _airportBusiness = airportBusiness;    
        }

        public IEnumerable<AirportViewModel> BuildAirportList()
        {
            var airportModels = _airportBusiness.GetAllAirports();
            
            return airportModels.Select(a => new AirportViewModel(a.Code, a.Name));
        }
    }
}