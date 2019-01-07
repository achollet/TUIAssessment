using System.Collections.Generic;
using TUIAssessment.Web.Models;
using TUIAssessmentBusiness.Models;

namespace TUIAssessmentWeb.Controllers
{
    public interface IFlightViewModelBuilder
    {
        FlightViewModel Build(FlightModel flightModel);
        FlightModel ConvertFlightViewModelToFlightModel(FlightViewModel flightViewModel);
        IEnumerable<FlightViewModel> BuildFlightViewModels();
    }
}