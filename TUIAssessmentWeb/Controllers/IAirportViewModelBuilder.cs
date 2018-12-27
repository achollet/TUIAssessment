using System.Collections.Generic;
using TUIAssessment.Web.Models;

namespace TUIAssessment.Web.Controllers
{
    public interface IAirportViewModelBuilder
    {
        IEnumerable<AirportViewModel> BuildAirportList();
    }
}