namespace TUIAssessment.Web.Models
{
    public class AirportViewModel
    {
        public string Code { get; set; }
        public string Name { get; set; }

        public AirportViewModel(string code, string name)
        {
            Code = code;
            Name = name;
        }
    }
}