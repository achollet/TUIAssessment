using System.Collections.Generic;
using TUIAssessment.DAL.Entities;

namespace TUIAssessment.DAL
{
    public interface ITUIAssessmentDAL
    {
        AirportEntity GetAirportEntityByID(int Id);
        IEnumerable<AirportEntity> GetAirportEntities();
        FlightEntity GetFlightEntityByID(int Id);
        IEnumerable<FlightEntity> GetFlightEntities();
        FlightEntity UpdateFlightEntity(FlightEntity flight);
        FlightEntity SaveFlightEntity(FlightEntity flight);
        bool RemoveFlightEntityByID(int Id);
    }
}