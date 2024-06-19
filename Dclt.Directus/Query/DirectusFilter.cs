using System.Text.Json;
using System.Text.Json.Serialization;

namespace Dclt.Directus;

public class DirectusFilter
{
    private readonly Dictionary<string, object> _filters;

    public DirectusFilter()
    {
        _filters = new Dictionary<string, object>();
    }

    public DirectusFilter AddFilter(string key, string operation, object value)
    {
        _filters[key] = new Dictionary<string, object> { { operation, value } };
        return this;
    }

    public DirectusFilter And(DirectusFilter[] filters)
    {
        _filters[Operation.And] = filters;
        return this;
    }

    public DirectusFilter Or(DirectusFilter[] filters)
    {
        _filters[Operation.Or] = filters;
        return this;
    }

    public DirectusFilter Equal(string field, object value)
    {
        _filters[field] = new Dictionary<string, object> { { Operation.Equal, value } };
        return this;
    }

    public DirectusFilter NotEqual(string field, object value)
    {
        _filters[field] = new Dictionary<string, object> { { Operation.NotEqual, value } };
        return this;
    }

    public DirectusFilter GreaterThan(string field, object value)
    {
        _filters[field] = new Dictionary<string, object> { { Operation.GreaterThan, value } };
        return this;
    }

    public DirectusFilter GreaterThanOrEqual(string field, object value)
    {
        _filters[field] = new Dictionary<string, object> { { Operation.GreaterThanOrEqual, value } };
        return this;
    }

    public DirectusFilter LessThan(string field, object value)
    {
        _filters[field] = new Dictionary<string, object> { { Operation.LessThan, value } };
        return this;
    }

    public DirectusFilter LessThanOrEqual(string field, object value)
    {
        _filters[field] = new Dictionary<string, object> { { Operation.LessThanOrEqual, value } };
        return this;
    }

    public DirectusFilter In(string field, IEnumerable<object> values)
    {
        _filters[field] = new Dictionary<string, object> { { Operation.In, values } };
        return this;
    }

    public DirectusFilter NotIn(string field, IEnumerable<object> values)
    {
        _filters[field] = new Dictionary<string, object> { { Operation.NotIn, values } };
        return this;
    }

    public DirectusFilter Between(string field, object start, object end)
    {
        _filters[field] = new Dictionary<string, object> { { Operation.Between, new[] { start, end } } };
        return this;
    }

    public DirectusFilter NotBetween(string field, object start, object end)
    {
        _filters[field] = new Dictionary<string, object> { { Operation.NotBetween, new[] { start, end } } };
        return this;
    }

    public DirectusFilter IsNull(string field)
    {
        _filters[field] = new Dictionary<string, object> { { Operation.IsNull, true } };
        return this;
    }

    public DirectusFilter IsNotNull(string field)
    {
        _filters[field] = new Dictionary<string, object> { { Operation.IsNotNull, true } };
        return this;
    }

    public DirectusFilter Contains(string field, string value)
    {
        _filters[field] = new Dictionary<string, object> { { Operation.Contains, value } };
        return this;
    }

    public DirectusFilter NotContains(string field, string value)
    {
        _filters[field] = new Dictionary<string, object> { { Operation.NotContains, value } };
        return this;
    }

    public string ToJson()
    {
        var json = JsonSerializer.Serialize(_filters, new JsonSerializerOptions()
        {
            WriteIndented = true,
            Converters = { new FilterConverter() }
        });
        return json;
    }

    private class FilterConverter : JsonConverter<DirectusFilter>
    {
        public override DirectusFilter Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, DirectusFilter value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value._filters, options);
        }
    }
}

