using Microsoft.Extensions.DependencyInjection;

namespace TUIAssessment.DAL
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddTUIAssessmentDALExtension(this IServiceCollection services)
        {
            services.AddTransient<ITUIAssessmentDAL, TUIAssessmentDAL>();

            return services;
        }
    }
}