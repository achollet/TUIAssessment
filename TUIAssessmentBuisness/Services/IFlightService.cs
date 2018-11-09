using TUIAssessmentBuisness.Models;

namespace TUIAssessmentBuisness.Services
{
    public interface IFlightService
    {
        double CalculateDistanceBetweenTwoPoints(CoordinatesModel coordinates1, CoordinatesModel coordinates2);
        double CalculateFuelVolumeForFlight(double distance, double consumption, double takeOffStress);
    }
}