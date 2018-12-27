using System.Collections.Generic;
using TUIAssessment.Web.Models;
using TUIAssessmentBusiness.Models;

namespace TUIAssessment.Web.Controllers
{
    public interface IFlightViewModelBuilder
    {
        FlightViewModel Build(FlightModel flightModel);
        FlightModel ConvertFlightViewModelToFlightModel(FlightViewModel flightViewModel);
        IEnumerable<FlightViewModel> BuildFlightViewModels();
    }
}