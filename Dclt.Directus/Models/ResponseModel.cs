namespace Dclt.Directus.Models;

public class ResponseModel<TData> where TData : class
{
    public long Id { get; set; }
    public TData? Data { get; set; }
}

