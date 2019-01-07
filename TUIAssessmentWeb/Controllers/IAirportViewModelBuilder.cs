using System.Collections.Generic;
using TUIAssessment.Web.Models;

namespace TUIAssessmentWeb.Controllers
{
    public interface IAirportViewModelBuilder
    {
        IEnumerable<AirportViewModel> BuildAirportList();
    }
}