using System;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TUIAssessment.Web.Models;
using TUIAssessmentBusiness.Interfaces;
using TUIAssessmentBusiness.Models;
using TUIAssessmentWeb.Controllers;

namespace TUIAssessmentTest.Builder
{
    [TestClass]
    public class FlightViewModelBuilderTest
    {
        private Mock<IAirportBusiness> _airportBusiness;
        private Mock<IFlightBusiness> _flightBusiness;
        private FlightViewModelBuilder _flightViewModelBuiler;

        [TestInitialize]
        public void Init()
        {
            _airportBusiness = new Mock<IAirportBusiness>();
            _flightBusiness = new Mock<IFlightBusiness>();

            _airportBusiness.Setup(ab => ab.GetAllAirports()).Returns(new List<AirportModel>
            {
                new AirportModel{Id = 1, Code = "CDG", Name = "Charles De Gaulle Airport", TakeOffEffort = 900.0, Coordinates = new CoordinatesModel(49.012780, 2.550000)},
                new AirportModel{Id = 2, Code = "JFK", Name = "John Fitzgerald Kennedy Airport", TakeOffEffort = 600.0, Coordinates = new CoordinatesModel(40.6398, -73.7789)},
                new AirportModel{Id = 3, Code = "LAX", Name = "Los Angeles International Airport", TakeOffEffort = 720.0, Coordinates = new CoordinatesModel(34.052230, -118.243680)},
                new AirportModel{Id = 4, Code = "HDN", Name = "Tokyo-Haneda International Airport", TakeOffEffort = 1163.0, Coordinates = new CoordinatesModel(35.552260, 139.779690)},
                new AirportModel{Id = 5, Code = "CPH", Name = "Copenhagen International Airport", TakeOffEffort = 637.0, Coordinates = new CoordinatesModel(55.623564, 12.660777)}
            });

            _flightBusiness.Setup(sb => sb.GetAllFlights()).Returns(new List<FlightModel>
            {   
                new FlightModel{ ID = 1, 
                                DepartureAirport = new AirportModel{Id = 1, Code = "CDG", Name = "Charles De Gaulle Airport", TakeOffEffort = 900.0, Coordinates = new CoordinatesModel(49.012780, 2.550000)},
                                ArrivalAirport = new AirportModel{Id = 2, Code = "JFK", Name = "John Fitzgerald Kennedy Airport", TakeOffEffort = 600.0, Coordinates = new CoordinatesModel(40.6398, -73.7789)},
                                Distance = 6666.66, Carburant = 42.0, Duration = 12.0
                                },
                new FlightModel{ ID = 2, 
                                DepartureAirport = new AirportModel{Id = 2, Code = "JFK", Name = "John Fitzgerald Kennedy Airport", TakeOffEffort = 600.0, Coordinates = new CoordinatesModel(40.6398, -73.7789)},
                                ArrivalAirport = new AirportModel{Id = 3, Code = "LAX", Name = "Los Angeles International Airport", TakeOffEffort = 720.0, Coordinates = new CoordinatesModel(34.052230, -118.243680)},
                                Distance = 6666.66, Carburant = 42.0, Duration = 12.0
                                },
                new FlightModel{ ID = 3, 
                                DepartureAirport = new AirportModel{Id = 3, Code = "LAX", Name = "Los Angeles International Airport", TakeOffEffort = 720.0, Coordinates = new CoordinatesModel(34.052230, -118.243680)},
                                ArrivalAirport = new AirportModel{Id = 5, Code = "CPH", Name = "Copenhagen International Airport", TakeOffEffort = 637.0, Coordinates = new CoordinatesModel(55.623564, 12.660777)},
                                Distance = 6666.66, Carburant = 42.0, Duration = 12.0
                                },
                new FlightModel{ ID = 4, 
                                DepartureAirport = new AirportModel{Id = 2, Code = "JFK", Name = "John Fitzgerald Kennedy Airport", TakeOffEffort = 600.0, Coordinates = new CoordinatesModel(40.6398, -73.7789)},
                                ArrivalAirport = new AirportModel{Id = 5, Code = "CPH", Name = "Copenhagen International Airport", TakeOffEffort = 637.0, Coordinates = new CoordinatesModel(55.623564, 12.660777)}, 
                                Distance = 6666.66, Carburant = 42.0, Duration = 12.0
                                },
                new FlightModel{ ID = 5, 
                                DepartureAirport = new AirportModel{Id = 1, Code = "CDG", Name = "Charles De Gaulle Airport", TakeOffEffort = 900.0, Coordinates = new CoordinatesModel(49.012780, 2.550000)},
                                ArrivalAirport = new AirportModel{Id = 3, Code = "LAX", Name = "Los Angeles International Airport", TakeOffEffort = 720.0, Coordinates = new CoordinatesModel(34.052230, -118.243680)},
                                Distance = 6666.66, Carburant = 42.0, Duration = 12.0
                                }
                });

            _flightViewModelBuiler = new FlightViewModelBuilder(_flightBusiness.Object, _airportBusiness.Object);
        }

        [TestMethod]
        public void GivenAFlightViewModel_ShouldReturnFlightModel()
        {
            var inputFlightViewModel = new FlightViewModel
            {
                Id = 1,
                DepartureAirportCode = "CDG",
                ArrivalAirportCode = "CPH",
                Distance = 666,
                TimeOfFlight = "3h14min15s",
                VolumeOfCarburant = 45,
                CreationDate = DateTime.ParseExact("2018-05-08 14:40:52", "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture),                       
            };

            var expectedFlightModel = new FlightModel
            {
                ID = 1,
                DepartureAirport = new AirportModel{Id = 1, Code = "CDG", Name = "Charles De Gaulle Airport", TakeOffEffort = 900.0, Coordinates = new CoordinatesModel(49.012780, 2.550000)},
                ArrivalAirport = new AirportModel{Id = 5, Code = "CPH", Name = "Copenhagen International Airport", TakeOffEffort = 637.0, Coordinates = new CoordinatesModel(55.623564, 12.660777)},
                Distance = 666,
                Carburant = 45,
                Duration = 3.2375,
                Creation = DateTime.ParseExact("2018-05-08 14:40:52", "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture)
            };

            var result = _flightViewModelBuiler.ConvertFlightViewModelToFlightModel(inputFlightViewModel);
            
            result.Should().NotBeNull();
            result.ID.Should().Equals(expectedFlightModel.ID);
            result.DepartureAirport.Code.Should().Equals(expectedFlightModel.DepartureAirport.Code);
            result.ArrivalAirport.Code.Should().Equals(expectedFlightModel.ArrivalAirport.Code);
            result.Distance.Should().Equals(expectedFlightModel.Distance);
            result.Duration.Should().Equals(expectedFlightModel.Duration);
            result.Carburant.Should().Equals(expectedFlightModel.Carburant);
            result.Creation.Should().Equals(expectedFlightModel.Creation);
        }

        [TestMethod]
        public void GivenFlightModel_ShouldReturnFlightView()
        {
            var inputFlightModel = new FlightModel
            {
                ID = 1,
                DepartureAirport = new AirportModel{Id = 1, Code = "CDG", Name = "Charles De Gaulle Airport", TakeOffEffort = 900.0, Coordinates = new CoordinatesModel(49.012780, 2.550000)},
                ArrivalAirport = new AirportModel{Id = 5, Code = "CPH", Name = "Copenhagen International Airport", TakeOffEffort = 637.0, Coordinates = new CoordinatesModel(55.623564, 12.660777)},
                Distance = 666,
                Carburant = 45,
                Duration = 3.2375,
                Creation = DateTime.ParseExact("2018-05-08 14:40:52", "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture)
            };

            var expectedFlightViewModel = new FlightViewModel
            {
                Id = 1,
                DepartureAirportCode = "CDG",
                ArrivalAirportCode = "CPH",
                Distance = 666,
                TimeOfFlight = "3h14min15s",
                VolumeOfCarburant = 45,
                CreationDate = DateTime.ParseExact("2018-05-08 14:40:52", "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture),                       
            };

            var result = _flightViewModelBuiler.Build(inputFlightModel);

            result.Should().NotBeNull();
            result.Id.Should().Equals(expectedFlightViewModel.Id);
            result.DepartureAirportCode.Should().Equals(expectedFlightViewModel.DepartureAirportCode);
            result.ArrivalAirportCode.Should().Equals(expectedFlightViewModel.ArrivalAirportCode);
            result.Distance.Should().Equals(expectedFlightViewModel.Distance);
            result.TimeOfFlight.Should().Equals(expectedFlightViewModel.TimeOfFlight);
            result.VolumeOfCarburant.Should().Equals(expectedFlightViewModel.VolumeOfCarburant);
            result.CreationDate.Should().Equals(expectedFlightViewModel.CreationDate);
        }
    }
}