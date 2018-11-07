using Microsoft.Extensions.DependencyInjection;

namespace TUIAssessmentWeb
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddTUIAssessmentWebExtension(this IServiceCollection services)
        {
            //services.AddTransient<, FlightBusiness>();
            //services.AddTransient<IAirportBusiness, AirportBusiness>();
            return services;
        }
    }
}