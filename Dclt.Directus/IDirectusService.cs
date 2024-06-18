namespace Dclt.Directus;

public interface IDirectusService
{
    Task<T?> GetItemsAsync<T>(string collection, string? query = null);
    Task<bool> CreateItemAsync<T>(string collection, T item);
}
