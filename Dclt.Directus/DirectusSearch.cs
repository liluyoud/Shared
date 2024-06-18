using Dclt.Directus.Models;
using System.Text.Json;

namespace Dclt.Directus;

public partial class DirectusClient
{
    // ?fields[]=sections.item:headings.id
    public async Task<string> GetItemsAsync(string collection)
    {
        //var queryString = queryParams != null ? BuildQueryString(queryParams) : string.Empty;
        var response = await _client.GetAsync($"/items/{collection}");

        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }

    public async Task<JsonElement> GetItemsAsync(string collection, string fields)
    {
        //var queryString = queryParams != null ? BuildQueryString(queryParams) : string.Empty;
        var url = $"/items/{collection}?{fields}";
        var response = await _client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<JsonElement>(content);
        return result.GetProperty("data");
    }


    public async Task<string> GetItemsAsync(string collection, Dictionary<string, string> queryParams = null)
    {
        var queryString = queryParams != null ? BuildQueryString(queryParams) : string.Empty;
        var response = await _client.GetAsync($"/items/{collection}{queryString}");

        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }

    private string BuildQueryString(Dictionary<string, string> queryParams)
    {
        var queryString = "?";
        foreach (var param in queryParams)
        {
            queryString += $"{param.Key}={param.Value}&";
        }
        return queryString.TrimEnd('&');
    }

    public Dictionary<string, string> CreateFieldsQuery(string fields)
    {
        return new Dictionary<string, string> { { "fields", fields } };
    }

    public Dictionary<string, string> CreateFilterQuery(Dictionary<string, object> filters)
    {
        return new Dictionary<string, string> { { "filter", JsonSerializer.Serialize(filters) } };
    }

    public Dictionary<string, string> CreateSortQuery(string sort)
    {
        return new Dictionary<string, string> { { "sort", sort } };
    }

    public Dictionary<string, string> CreateLimitQuery(int limit)
    {
        return new Dictionary<string, string> { { "limit", limit.ToString() } };
    }

    public Dictionary<string, string> CreateOffsetQuery(int offset)
    {
        return new Dictionary<string, string> { { "offset", offset.ToString() } };
    }

    public Dictionary<string, string> CreatePageQuery(int page)
    {
        return new Dictionary<string, string> { { "page", page.ToString() } };
    }

    public Dictionary<string, string> CreateSearchQuery(string search)
    {
        return new Dictionary<string, string> { { "search", search } };
    }

    public Dictionary<string, string> CreateDeepQuery(Dictionary<string, object> deepParams)
    {
        return new Dictionary<string, string> { { "deep", JsonSerializer.Serialize(deepParams) } };
    }

    public Dictionary<string, string> CreateAggregateQuery(Dictionary<string, string> aggregates)
    {
        var aggregateParams = new Dictionary<string, string>();
        foreach (var aggregate in aggregates)
        {
            aggregateParams.Add($"aggregate[{aggregate.Key}]", aggregate.Value);
        }
        return aggregateParams;
    }
}
