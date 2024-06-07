using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dclt.Shared.Extensions;
using Dclt.Shared.Models;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Dclt.Shared.Services;

public class DirectusService
{
    private readonly IHttpClientFactory _http;
    private readonly ILogger<DirectusService> _logger;
    private readonly IConfiguration _conf;
    private readonly HttpClient _client;
    private readonly IDistributedCache _cache; 

    public DirectusService(IHttpClientFactory http, ILogger<DirectusService> logger, IConfiguration conf, IDistributedCache cache)
    {
        _http = http;
        _logger = logger;
        _conf = conf;
        _cache = cache;

        var directusUrl = Environment.GetEnvironmentVariable("DIRECTUS_URL") ?? _conf["Environment:DIRECTUS_URL"] ?? throw new InvalidOperationException("DIRECTUS_URL not found.");
        var accessToken = Environment.GetEnvironmentVariable("DIRECTUS_TOKEN") ?? _conf["Environment:DIRECTUS_TOKEN"] ?? throw new InvalidOperationException("DIRECTUS_TOKEN not found.");

        _client = _http.CreateClient();
        _client = new HttpClient { BaseAddress = new Uri(directusUrl) };
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

    }

    public async Task<TData?> GetItemAsync<TData>(string collection, long id) where TData : class
    {
        var response = await _client.GetAsync($"/items/{collection}/{id}");
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            if (!string.IsNullOrEmpty(content))
            {
                var result = JsonSerializer.Deserialize<ResponseModel<TData>>(content, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                    NumberHandling = JsonNumberHandling.AllowReadingFromString,
                    AllowTrailingCommas = true,
                    PropertyNameCaseInsensitive = true
                });
                return result?.Data;
            }
        }
        return default;
    }

    public async Task<TData?> GetItemsAsync<TData>(string collection, string? filter = null) where TData : class
    {
        var endpoint = $"/items/{collection}";
        if (filter != null)
        {
            endpoint += $"?filter={filter}";
        }
        var response = await _client.GetAsync(endpoint);
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            if (!string.IsNullOrEmpty(content))
            {
                var result = JsonSerializer.Deserialize<ResponseModel<TData>>(content, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                    NumberHandling = JsonNumberHandling.AllowReadingFromString,
                    AllowTrailingCommas = true,
                    PropertyNameCaseInsensitive = true
                });
                return result?.Data;
            }
        }
        return default;
    }

    public async Task<TResponse?> CreateItemAsync<TRequest, TResponse>(string collection, TRequest item) where TRequest : class where TResponse : class
    {
        var json = JsonSerializer.Serialize(item, new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });

        var jsonContent = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _client.PostAsync($"/items/{collection}", jsonContent);
        if (response.IsSuccessStatusCode && response.Content != null)
        {
            var content = await response.Content.ReadAsStringAsync();
            if (!string.IsNullOrEmpty(content))
            {
                var result = JsonSerializer.Deserialize<ResponseModel<TResponse>>(content, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,   
                    NumberHandling = JsonNumberHandling.AllowReadingFromString,
                    AllowTrailingCommas = true
                });
                return result?.Data;
            }
        }
        return default;
    }

    public async Task<TData?> UpdateItemAsync<TData>(string collection, long id, TData item) where TData : class
    {
        var json = JsonSerializer.Serialize(item, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            NumberHandling = JsonNumberHandling.AllowReadingFromString,
            AllowTrailingCommas = true
        });

        var jsonContent = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _client.PatchAsync($"/items/{collection}/{id}", jsonContent);
        if (response.IsSuccessStatusCode && response.Content != null)
        {
            var content = await response.Content.ReadAsStringAsync();
            if (!string.IsNullOrEmpty(content))
            {
                var result = JsonSerializer.Deserialize<ResponseModel<TData>>(content, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                    AllowTrailingCommas = true
                });
                return result?.Data;
            }
        }
        return default;
    }

    public async Task<bool> DeleteItemAsync(string collection, long id)
    {
        var response = await _client.DeleteAsync($"/items/{collection}/{id}");
        if (response.IsSuccessStatusCode)
        {
            return true;
        }
        return false;
    }


    #region Cached
    public async Task<TData?> GetCachedItemsAsync<TData>(string key, string collection, int minutes, string? filter = null) where TData : class
    {
        var item = await _cache.GetAsync($"{collection}-{key}", async token => {

            return await GetItemsAsync<TData>(collection, filter);
        }, CacheOptions.GetExpiration(minutes));
        return item;
    }

    public async Task<TData?> GetCachedItemAsync<TData>(string collection, long id, int minutes) where TData : class
    {
        var item = await _cache.GetAsync($"{collection}-{id}", async token => {

            return await GetItemAsync<TData>(collection, id);
        }, CacheOptions.GetExpiration(minutes));
        return item;
    }
    #endregion
}
