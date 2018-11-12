using System;

namespace TUIAssessment.DAL.Entities
{
    public class FlightEntity
    {
        public int Id { get; set; }
        public int DepartureAirportId { get; set; }
        public int ArrivalAirportId { get; set; }
        public double Distance { get; set; }
        public double TimeOfFlight { get; set; }
        public double FuelQuantity { get; set}
        public DateTime Creation { get; set; }
        public DateTime Update { get; set; }
    }
}
