namespace Dclt.Directus;

public interface IDirectusService
{
    // Authentication
    Task<bool> AuthenticateAsync(string mail, string pwd);
    Task<DirectusUser?> AuthenticateAndGetUserAsync(string mail, string pwd);
    Task<bool> RefreshTokenAsync();
    Task<bool> LogoutAsync();
    Task<bool> RequestPasswordResetAsync(string email);
    Task<bool> ResetPasswordAsync(string token, string newPassword);


    // Items
    Task<T?> GetItemAsync<T>(string collection, long id);
    Task<T?> GetItemsAsync<T>(string collection, string? query = null);
    Task<bool> CreateItemAsync<T>(string collection, T item);
}
