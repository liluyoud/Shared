namespace Dclt.Directus;

public static class QueryExtension
{
    public static Query Filter(this Query query, string key, string operation, object value)
    {
        query.Filter.AddFilter(key, operation, value);
        return query;
    }

    public static Query FilterAnd(this Query query, DirectusFilter[] filters)
    {
        query.Filter.And(filters);
        return query;
    }

    public static Query FilterOr(this Query query, DirectusFilter[] filters)
    {
        query.Filter.Or(filters);
        return query;
    }

}
