using Dclt.Shared.Models;
using System.Text.Json.Serialization;

namespace Dclt.DemoConsole;

public class CacheModel<T>
{
    [JsonPropertyName("id")]
    public double? Id { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [JsonPropertyName("data")]
    public T? Data { get; set; }
}

public class ReadInverterModel
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("rpa_id")]
    public int RpaId { get; set; }

    [JsonPropertyName("date_created")]
    public DateTime ReadAt { get; set; }

    [JsonPropertyName("current")]
    public double? Current { get; set; }

    [JsonPropertyName("day")]
    public double? Day { get; set; }

    [JsonPropertyName("month")]
    public double? Month { get; set; }

    [JsonPropertyName("year")]
    public double? Year { get; set; }

    [JsonPropertyName("lifetime")]
    public double? Lifetime { get; set; }
}

public class RpaModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Type { get; set; }

    [JsonPropertyName("date_created")]
    public DateTime? DateCreated { get; set; }

    public List<KeyValue>? Settings { get; set; }
}