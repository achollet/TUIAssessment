using System.Collections.Generic;
using TUIAssessmentBusiness.Interfaces;
using TUIAssessmentBusiness.Models;

namespace TUIAssessmentBusiness
{
    public class AirportBusiness : IAirportBusiness
    {
        private IAirportRepository _airportRepository;

        public AirportBusiness(IAirportRepository airportRepository)
        {
            _airportRepository = airportRepository;
        }

        public AirportModel GetAirportById(int id) => _airportRepository.GetAirportModelByID(id);

        public IEnumerable<AirportModel> GetAllAirports() => _airportRepository.GetAirportModels();
    }
}