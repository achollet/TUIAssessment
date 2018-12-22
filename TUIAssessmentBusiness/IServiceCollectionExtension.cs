using Microsoft.Extensions.DependencyInjection;
using TUIAssessmentBusiness.Services;
using TUIAssessmentBusiness.Interfaces;

namespace TUIAssessmentBusiness
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