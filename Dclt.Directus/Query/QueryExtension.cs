namespace Dclt.Directus;

public static class QueryExtension
{
    public static DirectusQuery Filter(this DirectusQuery query, string key, string operation, object value)
    {
        query.Filter.AddFilter(key, operation, value);
        return query;
    }

    public static DirectusQuery FilterAnd(this DirectusQuery query, DirectusFilter[] filters)
    {
        query.Filter.And(filters);
        return query;
    }

    public static DirectusQuery FilterOr(this DirectusQuery query, DirectusFilter[] filters)
    {
        query.Filter.Or(filters);
        return query;
    }

}
