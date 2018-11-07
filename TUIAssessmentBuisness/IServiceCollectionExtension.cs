using Microsoft.Extensions.DependencyInjection;

namespace TUIAssessmentBuisness
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddTUIAssessmentBusinessExtension(this IServiceCollection services)
        {
            services.AddTransient<IFlightBusiness, FlightBusiness>();
            services.AddTransient<IAirportBusiness, AirportBusiness>();
            return services;
        }
    }
}