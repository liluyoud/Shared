using Dclt.Services.Cache;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;

namespace Dclt.Services.Helpers;

public static class CacheHelper
{
    public static void AddRedis(this IServiceCollection services, string url)
    {
        services.AddStackExchangeRedisCache(options => options.Configuration = url);
    }

    public static void AddRedis(this IServiceCollection services, IConfiguration conf)
    {
        var redisUrl = Environment.GetEnvironmentVariable("REDIS_URL") ?? conf["REDIS_URL"] ?? throw new ArgumentNullException("REDIS_URL not found.");
        services.AddStackExchangeRedisCache(options => options.Configuration = redisUrl);
    }

    public static async Task<T> GetOrCreateAsync<T>(
        this IDistributedCache cache,
        string key,
        Func<Task<T>> getMethod,
        DistributedCacheEntryOptions? options = null,
        CancellationToken cancellation = default)
    {
        var cachedData = await cache.GetStringAsync(key);
        if (string.IsNullOrEmpty(cachedData))
        {
            var data = await getMethod();
            if (data is not null)
            {
                string objectJson = JsonSerializer.Serialize(data);
                await cache.SetStringAsync(key, objectJson, options ?? CacheOptions.DefaultExpiration, cancellation);
                return data;
            }
            return default!;
        }
        return JsonSerializer.Deserialize<T>(cachedData)!;
    }
}
