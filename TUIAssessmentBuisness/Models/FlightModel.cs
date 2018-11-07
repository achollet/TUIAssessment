using System;

namespace TUIAssessmentBuisness.Models
{
    public class FlightModel
    {
        public int ID { get; set; }
        public string DepartureAirportID { get; set; }
        public string ArrivalAirportID { get; set; }
        public decimal Distance { get; set; }
        public decimal Carburant { get; set; }
        public decimal Duration { get; set; }
        public DateTime Creation { get; set; }
        public DateTime Update { get; set; }
    }
}