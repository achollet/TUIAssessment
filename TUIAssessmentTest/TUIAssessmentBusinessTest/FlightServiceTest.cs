using Microsoft.VisualStudio.TestTools.UnitTesting;
using TUIAssessmentBuisness.Services;
using TUIAssessmentBuisness.Models;
using Moq;

namespace TUIAssessmentTest.Business
{
    [TestClass]
    public class FlightServiceTest
    {
        [DataTestMethod]
        [DataRow(49.012780, 2.550000, 40.6398, -73.7789, 5833.66)]
        [DataRow(34.052230, -118.243680, 40.6398, -73.7789, 3955.40)]
        [DataRow(49.012780, 2.550000, 35.552260, 139.779690, 9706.83)]
        [DataRow(55.623564, 12.660777, -26.133480, 28.236060, 9210.66)]
        [DataRow(55.752220, 37.615560, -34.82218, -58.535843, 13502.94)]
        public void FlightService_CalculateDistance(double latitude1, double longitude1, double latitude2, double longitude2, double distanceBetween)
        {
            var coordinate1 = new CoordinatesModel(latitude1, longitude1);
            var coordinate2 = new CoordinatesModel(latitude2, longitude2);

            var flightService = new FlightService();

            var resultingDistance = flightService.CalculateDistanceWithHaversineFormulae(coordinate1, coordinate2);

            Assert.AreEqual(distanceBetween, resultingDistance);
        }

        [DataTestMethod]
        [DataRow(0.0, 0.0, 0.0, 0.0)]
        public void FlightService_CalculateFuelVolume(double distance, double consumption, double takeOffStress, double expectedVolume)
        {
            var flightService = new FlightService();

            var resultingVolume = flightService.CalculateFuelVolumeForFlight(distance, consumption, takeOffStress);

            Assert.AreEqual(expectedVolume, resultingVolume);
        }

         [DataTestMethod]
         [DataRow(4000.0, 960.0, 4.17)]
         public void FlightService_CalculateTimeOfFlight(double distance, double speed, double expectedTimeOfFlight)
         {
             var flightService = new FlightService();

             var resultingTimeOfFlight = flightService.CalculateTimeOfFlight(distance, speed);

             Assert.AreEqual(expectedTimeOfFlight, resultingTimeOfFlight);
         }
    }
}