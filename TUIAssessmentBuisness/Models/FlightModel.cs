using System;

namespace TUIAssessmentBuisness.Models
{
    public class FlightModel
    {
        public int ID { get; set; }
        public string DepartureAirportID { get; set; }
        public string ArrivalAirportID { get; set; }
        public double Distance { get; set; }
        public double Carburant { get; set; }
        public double Duration { get; set; }
        public DateTime Creation { get; set; }
        public DateTime Update { get; set; }
    }
}