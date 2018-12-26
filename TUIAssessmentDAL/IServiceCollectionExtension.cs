using TUIAssessmentBusiness.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace TUIAssessment.DAL
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddTUIAssessmentDALExtension(this IServiceCollection services)
        {
            services.AddTransient<IAirportRepository, SqlLiteAirportRepository>();
            services.AddTransient<IFlightRepository, SqlLiteFlightRepository>();
            services.AddTransient<ITUIAssessmentDAL, TUIAssessmentDAL>();
            services.AddTransient<IEntityToModelMapperService, EntityToModelMapperService>();

            return services;
        }
    }
}