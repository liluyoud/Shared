using Dclt.Chatwoot.Models.Api;
using System.Text.Json.Serialization;

namespace Dclt.Chatwoot.Contracts;

public class ContactsResponse
{
    [JsonPropertyName("count")]
    public int Count { get; set; }

    [JsonPropertyName("current_page")]
    public int CurrentPage { get; set; }

    [JsonPropertyName("current_page")]
    public List<Contact>? Data { get; set; }

}
