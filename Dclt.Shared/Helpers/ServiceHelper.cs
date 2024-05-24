using Dclt.Shared.Extensions;
using Dclt.Shared.Interfaces;
using Dclt.Shared.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Dclt.Shared.Helpers;

public static class ServiceHelper
{
    public static IServiceCollection AddDcltServices(this IServiceCollection services, string directusUrl, string accessToken)
    {
        services.AddHttpClient();
        //services.AddRefit<IDirectusService>(directusUrl, accessToken);
        services.AddScoped<HttpServices>();
        services.AddRefit<IOpenWeather>("http://api.openweathermap.org/data/2.5");
        return services;
    }

    public static bool IsServiceRegistered<TService>(this IServiceCollection services)
    {
        return services.Any(serviceDescriptor => serviceDescriptor.ServiceType == typeof(TService));
    }

    public static bool IsServiceRegistered(this IServiceCollection services, Type serviceType)
    {
        return services.Any(serviceDescriptor => serviceDescriptor.ServiceType == serviceType);
    }
}
