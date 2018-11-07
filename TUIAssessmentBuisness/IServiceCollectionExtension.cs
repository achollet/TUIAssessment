using Microsoft.Extensions.DependencyInjection;
using TUIAssessmentBuisness.Services;

namespace TUIAssessmentBuisness
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddTUIAssessmentBusinessExtension(this IServiceCollection services)
        {
            services.AddTransient<IFlightBusiness, FlightBusiness>();
            services.AddTransient<IAirportBusiness, AirportBusiness>();
            services.AddTransient<IFlightService, FlightService>();
            return services;
        }
    }
}