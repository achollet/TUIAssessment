using System;

namespace TUIAssessmentBusiness.Models
{
    public class FlightModel
    {
        public int ID { get; set; }
        public AirportModel DepartureAirport { get; set; }
        public AirportModel ArrivalAirport { get; set; }
        public double Distance { get; set; }
        public double Carburant { get; set; }
        public double Duration { get; set; }
        public DateTime Creation { get; set; }
        public DateTime Update { get; set; }
    }
}