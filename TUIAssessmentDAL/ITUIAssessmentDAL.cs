using System.Collections.Generic;
using TUIAssessment.DAL.Entities;

namespace TUIAssessment.DAL
{
    public interface ITUIAssessmentDAL
    {
        AirportEntity GetAirportEntityByID(int id);
        IEnumerable<AirportEntity> GetAirportEntities();
        FlightEntity GetFlightEntityByID(int id);
        IEnumerable<FlightEntity> GetFlightEntities();
        bool DeleteFlightEntityByID(int id);
        bool SaveFlightEntity(FlightEntity flightEntity);
        bool UpdateFlightEntity(FlightEntity flightEntity);
    }
}