using Microsoft.Extensions.Caching.Distributed;
using System.Buffers;
using System.Text.Json;

namespace Dclt.Shared.Extensions;

public static class CacheExtension
{
    public static async Task<T?> GetObjectAsync<T>(this IDistributedCache cache, string key)
    {
        var cachedData = await cache.GetStringAsync(key);
        if (string.IsNullOrEmpty(cachedData))
        {
            return default;
        }
        return JsonSerializer.Deserialize<T>(cachedData);
    }

    public static async Task SetObjectAsync<T>(this IDistributedCache cache, string key, T? objectToCache, CancellationToken cancellation = default)
    {
        if (objectToCache != null)
        {
            string objectJson = JsonSerializer.Serialize(objectToCache);
            await cache.SetStringAsync(key, objectJson, cancellation);
        }
    }

    public static async Task SetObjectAsync<T>(this IDistributedCache cache, string key, T? objectToCache, DistributedCacheEntryOptions options, CancellationToken cancellation = default)
    {
        if (objectToCache != null)
        {
            string objectJson = JsonSerializer.Serialize(objectToCache);
            await cache.SetStringAsync(key, objectJson, options, cancellation);
        }
    }

    public static ValueTask<T> GetAsync<T>(this IDistributedCache cache, string key, Func<CancellationToken, ValueTask<T>> getMethod,
        DistributedCacheEntryOptions? options = null, CancellationToken cancellation = default)
        => GetAsyncShared<int, T>(cache, key, state: 0, getMethod, options, cancellation); // use dummy state

    public static ValueTask<T> GetAsync<T>(this IDistributedCache cache, string key, Func<T> getMethod,
        DistributedCacheEntryOptions? options = null, CancellationToken cancellation = default)
        => GetAsyncShared<int, T>(cache, key, state: 0, getMethod, options, cancellation); // use dummy state

    public static ValueTask<T> GetAsync<TState, T>(this IDistributedCache cache, string key, TState state, Func<TState, CancellationToken, ValueTask<T>> getMethod,
        DistributedCacheEntryOptions? options = null, CancellationToken cancellation = default)
        => GetAsyncShared<TState, T>(cache, key, state, getMethod, options, cancellation);

    public static ValueTask<T> GetAsync<TState, T>(this IDistributedCache cache, string key, TState state, Func<TState, T> getMethod,
        DistributedCacheEntryOptions? options = null, CancellationToken cancellation = default)
        => GetAsyncShared<TState, T>(cache, key, state, getMethod, options, cancellation);

    private static ValueTask<T> GetAsyncShared<TState, T>(IDistributedCache cache, string key, TState state, Delegate getMethod,
        DistributedCacheEntryOptions? options, CancellationToken cancellation)
    {
        var pending = cache.GetAsync(key, cancellation);
        if (!pending.IsCompletedSuccessfully)
        {
            return Awaited(cache, key, pending, state, getMethod, options, cancellation);
        }

        var bytes = pending.GetAwaiter().GetResult();
        if (bytes is null)
        {
            return Awaited(cache, key, null, state, getMethod, options, cancellation);
        }

        return new(Deserialize<T>(bytes));

        static async ValueTask<T> Awaited(
            IDistributedCache cache, // the underlying cache
            string key, // the key on the cache
            Task<byte[]?>? pending, // incomplete "get bytes" operation, if any
            TState state, // state possibly used by the get-method
            Delegate getMethod, // the get-method supplied by the caller
            DistributedCacheEntryOptions? options, // cache expiration, etc
            CancellationToken cancellation)
        {
            byte[]? bytes;
            if (pending is not null)
            {
                bytes = await pending;
                if (bytes is not null)
                {   // data was available asynchronously
                    return Deserialize<T>(bytes);
                }
            }
            var result = getMethod switch
            {
                // we expect 4 use-cases; sync/async, with/without state
                Func<TState, CancellationToken, ValueTask<T>> get => await get(state, cancellation),
                Func<TState, T> get => get(state),
                Func<CancellationToken, ValueTask<T>> get => await get(cancellation),
                Func<T> get => get(),
                _ => throw new ArgumentException(nameof(getMethod)),
            };
            bytes = Serialize<T>(result);
            if (bytes is not null) // my implementation to not cache null values
            {
                if (options is null)
                {   // not recommended; cache expiration should be considered
                    // important, usually
                    await cache.SetAsync(key, bytes, cancellation);
                }
                else
                {
                    await cache.SetAsync(key, bytes, options, cancellation);
                }
            }
            return result;
        }
    }

    private static T Deserialize<T>(byte[] bytes)
    {
        return JsonSerializer.Deserialize<T>(bytes)!;
    }

    private static byte[] Serialize<T>(T value)
    {
        var buffer = new ArrayBufferWriter<byte>();
        using var writer = new Utf8JsonWriter(buffer);
        JsonSerializer.Serialize(writer, value);
        return buffer.WrittenSpan.ToArray();
    }
}

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

    public static DistributedCacheEntryOptions GetExpiration(int minutes)
    {
        return new() { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(minutes) };
    }

}