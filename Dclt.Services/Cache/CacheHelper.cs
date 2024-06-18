using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dclt.Services.Helpers;

public static class CacheHelper
{
    public static void AddRedis(this IServiceCollection services, string url)
    {
        services.AddStackExchangeRedisCache(options => options.Configuration = url);
    }

    public static void AddRedis(this IServiceCollection services, IConfiguration conf)
    {
        var redisUrl = Environment.GetEnvironmentVariable("REDIS_URL") ?? conf["Environment:REDIS_URL"] ?? throw new ArgumentNullException("REDIS_URL not found.");
        services.AddStackExchangeRedisCache(options => options.Configuration = redisUrl);
    }
}
