using System.Text.Json;

namespace Dclt.Directus;

public class Query
{
    private string? _fields;
    private string? _sorts;
    private string? _search;
    private int? _offset;
    private int? _page;
    private int? _limit;

    //public Query Fields(string fields)
    //{
    //    if (!string.IsNullOrWhiteSpace(fields))
    //    {
    //        _fields = fields.Split(',').Select(f => f.Trim()).ToArray();
    //    }
    //    return this;
    //}

    public Query Search(string search)
    {
        if (!string.IsNullOrWhiteSpace(search))
            _search = search;
        return this;
    }

    public Query Fields(string fields)
    {
        if (!string.IsNullOrWhiteSpace(fields))
            _fields = fields;
        return this;
    }

    public Query Sort(string sorts)
    {
        if (!string.IsNullOrWhiteSpace(sorts))
            _sorts = sorts;
        return this;
    }
    public Query Limit(int limit)
    {
        if (limit > 0)
            _limit = limit;
        return this;
    }

    public Query Offset(int offset)
    {
        if (offset > 0)
            _offset = offset;
        return this;
    }

    public Query Page(int page)
    {
        if (page > 0)
            _page = page;
        return this;
    }

    public string Build()
    {
        var query = "";
        if (_search != null && _search.Length > 0)
            query += "&search=" + _search;

        if (_fields != null && _fields.Length > 0)
            query += "&fields=" + _fields;

        if (_sorts != null && _sorts.Length > 0)
            query += "&sort=" + _sorts;

        if (_fields != null && _limit > 0) 
            query += "&limit=" + _limit ;

        if (_offset != null && _offset > 0)
            query += "&offset=" + _offset;

        if (_page != null && _page > 0)
            query += "&page=" + _page;

        return query.Substring(1);

    }
}
