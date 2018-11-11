using System;

namespace TUIAssessmentBuisness.Models
{
    public class FlightModel
    {
        public int ID { get; set; }
        public AirportModel DepartureAirport { get; set; }
        public AirportModel ArrivalAirport { get; set; }
        public double Distance { get; set; }
        public double Carburant { get; set; }
        public double Duration { get; set; }
        public string Creation { get; set; }
        public string Update { get; set; }
    }
}