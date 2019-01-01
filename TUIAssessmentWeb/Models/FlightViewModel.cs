using System;

namespace TUIAssessment.Web.Models
{
    public class FlightViewModel
    {
        public int Id { get; set; }
        public string DepartureAirportCode { get; set; }
        public string ArrivalAirportCode { get; set; }
        public double Distance { get; set; }
        public string TimeOfFlight { get; set; }
        public double VolumeOfCarburant { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}