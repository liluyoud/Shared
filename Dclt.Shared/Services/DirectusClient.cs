using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dclt.Shared.Extensions;
using Dclt.Shared.Models;
using Microsoft.Extensions.Caching.Distributed;

namespace Dclt.Shared.Services;

public class DirectusClient
{
    private readonly HttpClient _http;

    public DirectusClient(string baseUrl, string accessToken)
    {
        _http = new HttpClient { BaseAddress = new Uri(baseUrl) };
        _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
    }

    public async Task<TData?> GetItemAsync<TData>(string collection, long id) where TData : class
    {
        var response = await _http.GetAsync($"/items/{collection}/{id}");
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            if (!string.IsNullOrEmpty(content))
            {
                var result = JsonSerializer.Deserialize<ResponseModel<TData>>(content, new JsonSerializerOptions
                {
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                    AllowTrailingCommas = true,
                    PropertyNameCaseInsensitive = true
                });
                return result?.Data;
            }
        }
        return default;
    }

    public async Task<TData?> GetItemsAsync<TData>(string collection) where TData : class
    {
        var response = await _http.GetAsync($"/items/{collection}");
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            if (!string.IsNullOrEmpty(content))
            {
                var result = JsonSerializer.Deserialize<ResponseModel<TData>>(content, new JsonSerializerOptions
                {
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                    AllowTrailingCommas = true,
                    PropertyNameCaseInsensitive = true
                });
                return result?.Data;
            }
        }
        return default;
    }

    public async Task<TData?> CreateItemAsync<TData>(string collection, TData item) where TData : class
    {
        var json = JsonSerializer.Serialize(item, new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });

        var jsonContent = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _http.PostAsync($"/items/{collection}", jsonContent);
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

    public async Task<TData?> UpdateItemAsync<TData>(string collection, long id, TData item) where TData : class
    {
        var json = JsonSerializer.Serialize(item, new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });

        var jsonContent = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _http.PatchAsync($"/items/{collection}/{id}", jsonContent);
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
        var response = await _http.DeleteAsync($"/items/{collection}/{id}");
        if (response.IsSuccessStatusCode)
        {
            return true;
        }
        return false;
    }


    #region Cached
    public async Task<TData?> GetCachedItemAsync<TData>(string collection, long id, IDistributedCache cache, int minutes) where TData : class
    {
        var item = await cache.GetAsync($"{collection}-{id}", async token => {

            return await GetItemAsync<TData>(collection, id);
        }, CacheOptions.GetExpiration(minutes));
        return item;
    }
    #endregion
}
