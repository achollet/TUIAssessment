using TUIAssessmentBuisness.Models;

namespace TUIAssessmentBuisness.Services
{
    public interface IFlightService
    {
        decimal CalculateDistanceBetweenTwoAirports(AirportModel airport1, AirportModel airport2);
        decimal CalculateFuelVolumeForFlight(decimal distance, decimal consumption, decimal takeOffStress);
    }
}