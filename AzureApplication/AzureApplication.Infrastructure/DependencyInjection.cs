using AzureApplication.Core.Interfaces.Repositories;
using AzureApplication.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;


namespace AzureApplication.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IWeatherForecastRepository, WeatherForecastRepository>();
            return services;
        }
    }
}
