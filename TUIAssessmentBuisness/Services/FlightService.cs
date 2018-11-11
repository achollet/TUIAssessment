using System;
using TUIAssessmentBuisness.Models;

namespace TUIAssessmentBuisness.Services
{
    public class FlightService : IFlightService
    {
        private readonly double _earthRadius = 6371.0088;
        private readonly double _keroseneVolumetricMass = 0.800;

        /// <summary>
        /// This Method is used to calculate distance between two points at the surface of a sperical earth
        /// </summary>
        /// <param name="coordinates1"></param>
        /// <param name="coordinates2"></param>
        /// <returns>decimal</returns>
        public double CalculateDistanceWithHaversineFormulae(CoordinatesModel coordinates1, CoordinatesModel coordinates2)
        {
            var distance = HaversineFormulae(coordinates1, coordinates2);

            return distance;
        }

        /// <summary>
        /// This Method is used to calculate distance between two points at the surface of a ellipsoide earth
        /// </summary>
        /// <param name="coordinates1"></param>
        /// <param name="coordinates2"></param>
        /// <returns>decimal</returns>
        public double CalculateDistanceWithVicentyFormulae(CoordinatesModel coordinates1, CoordinatesModel coordinates2)
        {
            var distance = VicentyFormulae(coordinates1, coordinates2);

            return distance;
        }

        /// <summary>
        /// This Method is used to calculate the mass of fuel need to make the flight;
        /// </summary>
        /// <param name="distance">in kilometer</param>
        /// <param name="consumption">in cubicmeter per kilometer</param>
        /// <param name="takeOffStress">in kg of Kerosène</param>
        /// <returns>in Tons</returns>
        public double CalculateFuelVolumeForFlight(double distance, double consumption, double takeOffStress)
        {
            return Math.Round((consumption * distance) * _keroseneVolumetricMass + takeOffStress, 2);
        }

        ///<summary>
        /// calcultae time of flight in hours using a distance in km and a speed in km/h.
        ///</summary>
        ///<param name="distance">in kilometers</param>
        ///<param name="speed">in kilometers per hour</param>
        ///<returns>in hours</returns>
        public double CalculateTimeOfFlight(double distance, double speed)
        {
            return Math.Round(distance / speed, 2);
        }

        #region private methods

        private double HaversineFormulae(CoordinatesModel coordinates1, CoordinatesModel coordinates2)
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

        #endregion
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