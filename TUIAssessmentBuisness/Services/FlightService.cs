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
            var deltaLambda = Math.Abs(coordinates1.Longitude.ToRadians() - coordinates2.Longitude.ToRadians());
            var deltaPhi = Math.Abs(coordinates1.Latitude.ToRadians() - coordinates2.Latitude.ToRadians());

            var deltaSigma = Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(deltaPhi / 2), 2) + Math.Cos(coordinates1.Latitude.ToRadians()) * Math.Cos(coordinates2.Latitude.ToRadians()) * Math.Pow(Math.Sin(deltaLambda / 2), 2)));

            return Math.Round(2 * _earthRadius * deltaSigma, 2);
        }

        private double VicentyFormulae(CoordinatesModel coordinates1, CoordinatesModel coordinates2)
        {
            var deltaLambda = Math.Abs(coordinates1.Longitude.ToRadians() - coordinates2.Longitude.ToRadians());

            var numerator = Math.Sqrt(Math.Pow(Math.Cos(coordinates2.Latitude.ToRadians()) * Math.Sin(deltaLambda), 2) + Math.Pow(Math.Cos(coordinates1.Latitude.ToRadians()) * Math.Sin(coordinates2.Latitude.ToRadians() - Math.Sin(coordinates1.Latitude.ToRadians() * Math.Cos(coordinates2.Latitude.ToRadians()) * Math.Cos(deltaLambda))), 2));

            var denominator = Math.Sin(coordinates1.Latitude.ToRadians()) * Math.Sin(coordinates2.Latitude.ToRadians()) + Math.Cos(coordinates1.Latitude.ToRadians()) * Math.Cos(coordinates2.Latitude.ToRadians()) * Math.Cos(deltaLambda);

            var deltaSigma = Math.Atan(numerator / denominator);

            return Math.Round(2 * _earthRadius * deltaSigma, 2);
        }
    }

    /// <summary>
    /// Convert to Radians.
    /// </summary>
    /// <param name="val">The value to convert to radians</param>
    /// <returns>The value in radians</returns>
    public static class NumericExtensions
    {
        public static double ToRadians(this double val)
        {
            return (Math.PI / 180) * val;
        }
    }
}