using Dclt.Shared.Extensions;
using Dclt.Shared.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Dclt.Shared.Helpers;

public static class MapHelper
{
    public static IServiceCollection AddOpenWeather(this IServiceCollection services)
    {
        services.AddRefit<IOpenWeather>("http://api.openweathermap.org/data/2.5");
        return services;
    }
}
