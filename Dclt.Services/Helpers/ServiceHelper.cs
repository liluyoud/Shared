using Microsoft.Extensions.DependencyInjection;

namespace Dclt.Services.Helpers;

public static class ServiceHelper
{
    public static bool IsServiceRegistered<TService>(this IServiceCollection services)
    {
        return services.Any(serviceDescriptor => serviceDescriptor.ServiceType == typeof(TService));
    }

    public static bool IsServiceRegistered(this IServiceCollection services, Type serviceType)
    {
        return services.Any(serviceDescriptor => serviceDescriptor.ServiceType == serviceType);
    }
}
