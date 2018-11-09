using System;
using TUIAssessmentBuisness.Models;

namespace TUIAssessmentBuisness.Services
{
    public class FlightService : IFlightService
    {
        private readonly double _earthRadius = 6371.0088;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="coordinates1"></param>
        /// <param name="coordinates2"></param>
        /// <returns>decimal</returns>
        public double CalculateDistanceBetweenTwoPoints(CoordinatesModel coordinates1, CoordinatesModel coordinates2)
        {
            var distance = HaversineFormula(coordinates1, coordinates2);

            return distance;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="consumption"></param>
        /// <param name="takeOffStress"></param>
        /// <returns></returns>
        public double CalculateFuelVolumeForFlight(double distance, double consumption, double takeOffStress)
        {
            throw new System.NotImplementedException();
        }

        private double HaversineFormula(CoordinatesModel coordinates1, CoordinatesModel coordinates2)
        {
            var deltaLambda = Math.Abs(DegreeToRadian(coordinates1.Longitude) - DegreeToRadian(coordinates2.Longitude));
            var deltaPhi = Math.Abs(DegreeToRadian(coordinates1.Latitude) - DegreeToRadian(coordinates2.Latitude));

            var deltaSigma = Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(deltaPhi / 2), 2) + Math.Cos(DegreeToRadian(coordinates1.Latitude)) * Math.Cos(DegreeToRadian(coordinates2.Latitude)) * Math.Pow(Math.Sin(deltaLambda / 2), 2)));

            return Math.Round(2 * _earthRadius * deltaSigma, 2);
        }

        private double DegreeToRadian(double angle)
        {
            return (Math.PI / 180.0) * angle;
        }

    }
}