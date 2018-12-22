namespace TUIAssessmentBusiness.Models
{
    public class CoordinatesModel
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public CoordinatesModel(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}