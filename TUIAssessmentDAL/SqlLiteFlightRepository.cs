using System.Collections.Generic;
using TUIAssessment.DAL.Entities;
using TUIAssessmentBusiness.Interfaces;
using TUIAssessmentBusiness.Models;

namespace TUIAssessment.DAL
{
    public class SqlLiteFlightRepository : IFlightRepository
    {
        private readonly ITUIAssessmentDAL _TUIAssessmentDAL;
        private readonly IEntityToModelMapperService _entityToModelMapperService;

        public SqlLiteFlightRepository(ITUIAssessmentDAL TUIAssessmentDAL, IEntityToModelMapperService entityToModelMapperService)
        {
            _TUIAssessmentDAL = TUIAssessmentDAL;
            _entityToModelMapperService = entityToModelMapperService;
        }

        public FlightModel GetFlightByID(int Id)
        {
            var flightEntity = _TUIAssessmentDAL.GetFlightEntityByID(Id);
            var flightModel = _entityToModelMapperService.ConvertToFlightModel(flightEntity);
            return flightModel;
        }

        public IEnumerable<FlightModel> GetFlights()
        {
            var flightEntities = _TUIAssessmentDAL.GetFlightEntities();
            var flightModel = _entityToModelMapperService.ConvertToFlightModels(flightEntities);
            return flightModel;
        }

        public bool RemoveFlightByID(int Id)
        {
            return _TUIAssessmentDAL.DeleteFlightEntityByID(Id);
        }

        public bool SaveFlight(FlightModel flight)
        {
            FlightEntity flightEntity = _entityToModelMapperService.ConvertToFlightEntity(flight);
            return _TUIAssessmentDAL.SaveFlightEntity(flightEntity);
        }

        public FlightModel UpdateFlight(FlightModel flight)
        {
            FlightEntity flightEntity = _entityToModelMapperService.ConvertToFlightEntity(flight);
            _TUIAssessmentDAL.UpdateFlightEntity(flightEntity);
            var flightEntityUpdated = _TUIAssessmentDAL.GetFlightEntityByID(flightEntity.Id);
            return _entityToModelMapperService.ConvertToFlightModel(flightEntityUpdated);
        }
    }
}