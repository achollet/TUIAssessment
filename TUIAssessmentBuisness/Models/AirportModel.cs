namespace TUIAssessmentBuisness.Models
{
    public class AirportModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public CoordinatesModel Coordinates { get; set; }
        public double TakeOffEffort { get; set; }
    }
}