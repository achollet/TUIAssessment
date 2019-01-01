using System;
using System.Collections.Generic;
using System.Linq;
using TUIAssessment.Web.Controllers;
using TUIAssessment.Web.Models;
using TUIAssessmentBusiness.Interfaces;
using TUIAssessmentBusiness.Models;

namespace TUIAssessmentWeb.Controllers
{
    public class FlightViewModelBuilder : IFlightViewModelBuilder
    {
        private readonly IFlightBusiness _flightBusiness;
        private readonly IAirportBusiness _airportBusiness;
        public FlightViewModelBuilder(IFlightBusiness flightBusiness, IAirportBusiness airportBusiness)
        {
            _flightBusiness = flightBusiness;
            _airportBusiness = airportBusiness;
        }

        public FlightViewModel Build(FlightModel flightModel) => 
        new FlightViewModel
        {
            Id = flightModel.ID,
            DepartureAirportCode = flightModel.DepartureAirport.Code, 
            ArrivalAirportCode = flightModel.ArrivalAirport.Code,
            Distance = flightModel.Distance,
            TimeOfFlight = ConvertDurationToTimeString(flightModel.Duration),
            VolumeOfCarburant = flightModel.Carburant,
            CreationDate = flightModel.Creation
        };

        public IEnumerable<FlightViewModel> BuildFlightViewModels() =>  _flightBusiness.GetAllFlights().Select(f => Build(f));

        public FlightModel ConvertFlightViewModelToFlightModel(FlightViewModel flightViewModel) 
        {
            var airports = _airportBusiness.GetAllAirports();
            var flight =  new FlightModel 
            {
                ID = flightViewModel.Id,
                DepartureAirport = airports.First(a => a.Code == flightViewModel.DepartureAirportCode),
                ArrivalAirport = airports.First(a => a.Code == flightViewModel.ArrivalAirportCode),
                Distance = flightViewModel.Distance,
                Carburant = flightViewModel.VolumeOfCarburant,
                Duration = ConvertTimeStringToDuration(flightViewModel.TimeOfFlight),
                Creation = flightViewModel.CreationDate,
                Update = flightViewModel.UpdateDate
            };

            return flight;
        }
        

        private string ConvertDurationToTimeString(double duration)
        {
            var hours = Math.Truncate(duration);
            var minutes = Math.Truncate(duration%hours*60);
            var seconds = (duration%hours*60%Math.Truncate(duration%hours*60));
            return $"{hours}h{minutes}min{seconds}s";
        }

        private double ConvertTimeStringToDuration(string timeOfFlight)
        {
            var hours = int.Parse(timeOfFlight.ToLower().Split("h").First().Trim());
            var minutes = int.Parse((timeOfFlight.ToLower().Split("h").Last().Trim()).Split("min").First().Trim());            
            var seconds = int.Parse((timeOfFlight.ToLower().Split("h").Last().Trim()).Split("min").Last().Trim().Split("s").First().Trim());
            return hours + (minutes/60) + (seconds/3600);
        }
    }
}