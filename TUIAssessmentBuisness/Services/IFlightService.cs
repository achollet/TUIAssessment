using TUIAssessmentBuisness.Models;

namespace TUIAssessmentBuisness.Services
{
    public interface IFlightService
    {
        double CalculateDistanceWithHaversineFormulae(CoordinatesModel coordinates1, CoordinatesModel coordinates2);
        double CalculateDistanceWithVicentyFormulae(CoordinatesModel coordinates1, CoordinatesModel coordinates2);
        double CalculateFuelVolumeForFlight(double distance, double consumption, double takeOffStress);
        double CalculateTimeOfFlight(double distance, double speed);
    }
}