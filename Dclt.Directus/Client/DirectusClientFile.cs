using System.Text;
using System.Text.Json;

namespace Dclt.Directus;

public partial class DirectusClient
{
    public async Task<string?> GetFileAsTextAsync(string file)
    {
        var url = $"/assets/{file}";
        var response = await _client.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsStringAsync();
        }
        return default;
    }
}
