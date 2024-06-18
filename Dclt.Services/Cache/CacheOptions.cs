using Microsoft.Extensions.Caching.Distributed;

namespace Dclt.Services.Cache;

public static class CacheOptions
{
    public static DistributedCacheEntryOptions DefaultExpiration => new() { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1) };
    public static DistributedCacheEntryOptions OneMinuteExpiration => new() { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1) };
    public static DistributedCacheEntryOptions FiveMinutesExpiration => new() { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5) };
    public static DistributedCacheEntryOptions TenMinutesExpiration => new() { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10) };
    public static DistributedCacheEntryOptions FifteenMinutesExpiration => new() { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(15) };
    public static DistributedCacheEntryOptions HalfHourExpiration => new() { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30) };
    public static DistributedCacheEntryOptions OneHourExpiration => new() { AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1) };
    public static DistributedCacheEntryOptions OneDayExpiration => new() { AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(1) };

    public static DistributedCacheEntryOptions SetExpiration(int minutes)
    {
        return new() { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(minutes) };
    }

}