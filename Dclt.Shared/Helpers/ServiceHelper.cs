using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dclt.Shared.Helpers;

public static class ServiceHelper
{
    public static void AddRedis(this IServiceCollection services, IConfiguration conf)
    {
        var redisUrl = Environment.GetEnvironmentVariable("REDIS_URL") ?? conf["Environment:REDIS_URL"] ?? throw new InvalidOperationException("REDIS_URL not found.");
        services.AddStackExchangeRedisCache(options => options.Configuration = redisUrl);
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
