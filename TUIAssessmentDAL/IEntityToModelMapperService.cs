using System.Collections.Generic;
using TUIAssessment.DAL.Entities;
using TUIAssessmentBusiness.Models;

namespace TUIAssessment.DAL
{
    public interface IEntityToModelMapperService
    {
        AirportModel ConvertToAirportModel(AirportEntity airportEntity);
        IEnumerable<AirportModel> ConvertToAirportModels(IEnumerable<AirportEntity> airportEntities);
        FlightModel ConvertToFlightModel(FlightEntity flightEntity);
        IEnumerable<FlightModel> ConvertToFlightModels(IEnumerable<FlightEntity> flightEntities);
        FlightEntity ConvertToFlightEntity(FlightModel flight);
    }
}