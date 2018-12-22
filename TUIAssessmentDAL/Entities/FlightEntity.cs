using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TUIAssessment.DAL.Entities

{
    [Table("Flights")]
    public class FlightEntity
    {
        [Key]
        public int Id { get; set; }
        public int DepartureAirportId { get; set; }
        public int ArrivalAirportId { get; set; }
        public double Distance { get; set; }
        public double TimeOfFlight { get; set; }
        public double FuelQuantity { get; set; }
        public DateTime Creation { get; set; }
        public DateTime Update { get; set; }
    }
}
