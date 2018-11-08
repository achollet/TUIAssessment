using TUIAssessmentBuisness.Models;

namespace TUIAssessmentBuisness.Services
{
    public class FlightService : IFlightService
    {
        public decimal CalculateDistanceBetweenTwoAirports(AirportModel airport1, AirportModel airport2)
        {
            //Calculate with Vincenty solutions and Haversine Formula
            throw new System.NotImplementedException();
        }

        public decimal CalculateFuelVolumeForFlight(decimal distance, decimal consumption, decimal takeOffStress)
        {
            throw new System.NotImplementedException();
        }
    }
}