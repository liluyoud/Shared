using System.Text.Json;

namespace Dclt.Directus;

public class DirectusFilter
{
    private readonly Dictionary<string, object> _filters;

    public DirectusFilter()
    {
        _filters = new Dictionary<string, object>();
    }

    public DirectusFilter Equal(string field, object value)
    {
        _filters[field] = new Dictionary<string, object> { { "_eq", value } };
        return this;
    }

    public DirectusFilter NotEqual(string field, object value)
    {
        _filters[field] = new Dictionary<string, object> { { "_neq", value } };
        return this;
    }

    public DirectusFilter GreaterThan(string field, object value)
    {
        _filters[field] = new Dictionary<string, object> { { "_gt", value } };
        return this;
    }

    public DirectusFilter GreaterThanOrEqual(string field, object value)
    {
        _filters[field] = new Dictionary<string, object> { { "_gte", value } };
        return this;
    }

    public DirectusFilter LessThan(string field, object value)
    {
        _filters[field] = new Dictionary<string, object> { { "_lt", value } };
        return this;
    }

    public DirectusFilter LessThanOrEqual(string field, object value)
    {
        _filters[field] = new Dictionary<string, object> { { "_lte", value } };
        return this;
    }

    public DirectusFilter In(string field, IEnumerable<object> values)
    {
        _filters[field] = new Dictionary<string, object> { { "_in", values } };
        return this;
    }

    public DirectusFilter NotIn(string field, IEnumerable<object> values)
    {
        _filters[field] = new Dictionary<string, object> { { "_nin", values } };
        return this;
    }

    public DirectusFilter Between(string field, object start, object end)
    {
        _filters[field] = new Dictionary<string, object> { { "_between", new[] { start, end } } };
        return this;
    }

    public DirectusFilter NotBetween(string field, object start, object end)
    {
        _filters[field] = new Dictionary<string, object> { { "_nbetween", new[] { start, end } } };
        return this;
    }

    public DirectusFilter IsNull(string field)
    {
        _filters[field] = new Dictionary<string, object> { { "_null", true } };
        return this;
    }

    public DirectusFilter IsNotNull(string field)
    {
        _filters[field] = new Dictionary<string, object> { { "_nnull", true } };
        return this;
    }

    public DirectusFilter Contains(string field, string value)
    {
        _filters[field] = new Dictionary<string, object> { { "_contains", value } };
        return this;
    }

    public DirectusFilter NotContains(string field, string value)
    {
        _filters[field] = new Dictionary<string, object> { { "_ncontains", value } };
        return this;
    }

    public Dictionary<string, object> Build()
    {
        return _filters;
    }

    public string ToJson()
    {
        return JsonSerializer.Serialize(_filters);
    }
}
