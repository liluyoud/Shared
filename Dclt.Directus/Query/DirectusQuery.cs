namespace Dclt.Directus;

public class DirectusQuery
{
    private string? _fields;
    private string? _sorts;
    private string? _search;
    private int? _offset;
    private int? _page;
    private int? _limit;
    private string? _export;  

    public DirectusFilter Filter { get; set; } = new DirectusFilter();

    public DirectusQuery Search(string search)
    {
        if (!string.IsNullOrWhiteSpace(search))
            _search = search;
        return this;
    }

    public DirectusQuery Fields(string fields)
    {
        if (!string.IsNullOrWhiteSpace(fields))
            _fields = fields;
        return this;
    }

    public DirectusQuery Sort(string sorts)
    {
        if (!string.IsNullOrWhiteSpace(sorts))
            _sorts = sorts;
        return this;
    }

    public DirectusQuery Limit(int limit)
    {
        if (limit > 0)
            _limit = limit;
        return this;
    }

    public DirectusQuery Offset(int offset)
    {
        if (offset > 0)
            _offset = offset;
        return this;
    }

    public DirectusQuery Page(int page)
    {
        if (page > 0)
            _page = page;
        return this;
    }

    public DirectusQuery Export(string export)
    {
        if (!string.IsNullOrWhiteSpace(export))
            _export = export;
        return this;
    }

    public string Build()
    {
        var query = "";
        if (_search != null && !string.IsNullOrWhiteSpace(_search))
            query += "&search=" + _search;

        if (_fields != null && !string.IsNullOrWhiteSpace(_fields))
            query += "&fields=" + _fields;

        if (_sorts != null && !string.IsNullOrWhiteSpace(_sorts))
            query += "&sort=" + _sorts;

        if (_fields != null && _limit > 0) 
            query += "&limit=" + _limit ;

        if (_offset != null && _offset > 0)
            query += "&offset=" + _offset;

        if (_page != null && _page > 0)
            query += "&page=" + _page;

        if (_export != null && !string.IsNullOrWhiteSpace(_export))
            query += "&export=" + _export;

        var filter = Filter.ToJson();
        if (filter != null && filter != "{}")
            query += "&filter=" + filter;

        return query.Substring(1);

    }
}
