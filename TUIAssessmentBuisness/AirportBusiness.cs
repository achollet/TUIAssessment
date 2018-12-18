using System.Collections.Generic;
using TUIAssessment.DAL;
using TUIAssessmentBuisness.Models;

namespace TUIAssessmentBuisness
{
    public class AirportBusiness : IAirportBusiness
    {
        private ITUIAssessmentDAL _TUIAssessmentDAL;

        public AirportBusiness(ITUIAssessmentDAL TUIAssessmentDAL)
        {
            _TUIAssessmentDAL = TUIAssessmentDAL;
        }

        public AirportModel GetAirportById(int id)
        {
            var airportEntity = _TUIAssessmentDAL.GetAirportEntityByID(id);
            return new AirportModel();
        }

        public IEnumerable<AirportModel> GetAllAirports()
        {
            throw new System.NotImplementedException();
        }
    }
}