using Dclt.Shared.Extensions;
using Dclt.Shared.Interfaces;
using Dclt.Shared.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Dclt.Shared.Helpers;

public static class ServiceHelper
{
    public static IServiceCollection AddDcltServices(this IServiceCollection services)
    {
        services.AddHttpClient();
        services.AddScoped<HttpServices>();
        services.AddRefit<IOpenWeather>("http://api.openweathermap.org/data/2.5");
        return services;
    }
}
