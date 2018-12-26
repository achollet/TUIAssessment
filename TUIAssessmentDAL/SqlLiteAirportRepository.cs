using System.Collections.Generic;
using TUIAssessment.DAL.Entities;
using TUIAssessmentBusiness.Interfaces;
using TUIAssessmentBusiness.Models;

namespace TUIAssessment.DAL
{
    public class SqlLiteAirportRepository : IAirportRepository
    {
        private readonly ITUIAssessmentDAL _TUIAssessmentDAL;
        private readonly IEntityToModelMapperService _entityToModelMapperService;

        public SqlLiteAirportRepository(ITUIAssessmentDAL TUIAssessmentDAL, IEntityToModelMapperService entityToModelMapperService)
        {
            _TUIAssessmentDAL = TUIAssessmentDAL;
            _entityToModelMapperService = entityToModelMapperService;
        }

        public AirportModel GetAirportModelByID(int Id)
        {
            var airportEntity = _TUIAssessmentDAL.GetAirportEntityByID(Id);
            var airportModel = _entityToModelMapperService.ConvertToAirportModel(airportEntity);
            return airportModel;
        }

        public IEnumerable<AirportModel> GetAirportModels()
        {
            var airportEntities = _TUIAssessmentDAL.GetAirportEntities();
            var airportModels = _entityToModelMapperService.ConvertToAirportModels(airportEntities);
            return airportModels;
        }
    }
}