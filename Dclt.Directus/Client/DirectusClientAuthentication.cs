using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace Dclt.Directus;

public partial class DirectusClient
{
    public async Task<bool> AuthenticateAsync(string mail, string pwd)
    {
        var requestBody = new { email = mail, password = pwd };
        var response = await _client.PostAsync("/auth/login",
            new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json"));

        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            var jsonResponse = JsonSerializer.Deserialize<JsonElement>(responseContent);
            accessToken = jsonResponse.GetProperty("data").GetProperty("access_token").GetString();
            refreshToken = jsonResponse.GetProperty("data").GetProperty("refresh_token").GetString();
            if (AccessToken != null)
            {
                _client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", AccessToken);
                return true;
            }
        }
        return false;
    }

    public async Task<DirectusUser?> AuthenticateAndGetUserAsync(string mail, string pwd)
    {
        var requestBody = new { email = mail, password = pwd };
        var response = await _client.PostAsync("/auth/login",
            new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json"));

        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            var jsonResponse = JsonSerializer.Deserialize<JsonElement>(responseContent);
            accessToken = jsonResponse.GetProperty("data").GetProperty("access_token").GetString();
            refreshToken = jsonResponse.GetProperty("data").GetProperty("refresh_token").GetString();
            if (AccessToken != null)
            {
                _client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", AccessToken);

                var responseUser = await _client.GetFromJsonAsync<JsonElement>("/users/me");
                var jsonUser = responseUser.GetProperty("data").GetRawText();
                var user = JsonSerializer.Deserialize<DirectusUser>(jsonUser);
                if (user != null)
                {
                    user.AccessToken = accessToken;
                    user.RefreshToken = refreshToken;
                    return user;
                }
            }
        }
        return null;
    }

    public async Task<bool> RefreshTokenAsync()
    {
        var requestBody = new { refresh_token = RefreshToken };
        var response = await _client.PostAsync("/auth/refresh",
            new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json"));

        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            var jsonResponse = JsonSerializer.Deserialize<JsonElement>(responseContent);
            accessToken = jsonResponse.GetProperty("data").GetProperty("access_token").GetString();
            refreshToken = jsonResponse.GetProperty("data").GetProperty("refresh_token").GetString();
            _client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", AccessToken);
            return true;
        } 
        return false;
    }

    public async Task<bool> LogoutAsync()
    {
        var response = await _client.PostAsync("/auth/logout", null);
        if (response.IsSuccessStatusCode)
        {
            accessToken = null;
            refreshToken = null;
            _client.DefaultRequestHeaders.Authorization = null;
            return true;
        }
        return false;
    }

    public async Task<bool> RequestPasswordResetAsync(string email)
    {
        var requestBody = new { email };
        var response = await _client.PostAsync("/auth/password/request",
            new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json"));
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> ResetPasswordAsync(string token, string newPassword)
    {
        var requestBody = new { token, password = newPassword };
        var response = await _client.PostAsync("/auth/password/reset",
            new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json"));
        return response.IsSuccessStatusCode;
    }
}
