using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Dclt.Directus;

public class DirectusAuthStateProvider : AuthenticationStateProvider
{
    private readonly DirectusService _directusService;
    private readonly ILocalStorageService _localStorage;

    private const string AuthenticationType = "DirectusAuth";
    private const string UserStorageKey = "user";

    public DirectusUser CurrentUser { get; set; } = new();
    private AuthenticationState EmptyAuthState => new(new ClaimsPrincipal());


    public DirectusAuthStateProvider(DirectusService directusService, ILocalStorageService localStorage)
    {
        _directusService = directusService;
        _localStorage = localStorage;
        AuthenticationStateChanged += DirectusAuthStateProvider_AuthenticationStateChanged;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var user = await _localStorage.GetItemAsync<DirectusUser>(UserStorageKey);
        if (user is null)
        {
            // User auth state is not in browser's session/local storage
            // User is not logged in
            CurrentUser = new();
            return EmptyAuthState;
        }
        else
        {
            //  User auth state is there in the browser's session/local storage
            // User is logged in, we can fill out user details from this storage
            CurrentUser = user;

            var authState = GenerateAuthState(user);
            return authState;
        }
    }

    private async void DirectusAuthStateProvider_AuthenticationStateChanged(Task<AuthenticationState> task)
    {
        var authState = await task;
        if (authState is not null)
        {
            var idStr = authState.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!string.IsNullOrWhiteSpace(idStr) )
            {
                CurrentUser = new DirectusUser
                {
                    Id = Guid.Parse(idStr),
                    FirstName = authState.User.FindFirst(ClaimTypes.Name)?.Value,
                    LastName = authState.User.FindFirst(ClaimTypes.GivenName)?.Value,
                    Email = authState.User.FindFirst(ClaimTypes.Email)?.Value,
                    AccessToken = authState.User.FindFirst("AccessToken")?.Value,
                    RefreshToken = authState.User.FindFirst("RefreshToken")?.Value
                };
                return;
            }
        }
        CurrentUser = new();
    }

    public async Task<bool> LoginAsync(string username, string password)
    {
        // Make Api Call with these Username and PAssword
        // and obtain the User Info from the api server
        var user = await _directusService.AuthenticateAndGetUserAsync(username, password);
        if (user is not null)
        {
            await _localStorage.SetItemAsync(UserStorageKey, user);
            var authState = GenerateAuthState(user);
            NotifyAuthenticationStateChanged(Task.FromResult(authState));
            return true;
        }
        return false;
    }

    public async Task LogoutAsync()
    {
        await _localStorage.RemoveItemAsync(UserStorageKey);
        NotifyAuthenticationStateChanged(Task.FromResult(EmptyAuthState));
    }

    private AuthenticationState GenerateAuthState(DirectusUser user)
    {
        Claim[] claims = [
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.FirstName!),
            new Claim(ClaimTypes.GivenName, user.LastName!),
            new Claim(ClaimTypes.Email, user.Email!),
            new Claim("AccessToken", user.AccessToken!),
            new Claim("RefreshToken", user.RefreshToken!),
        ];

        var identity = new ClaimsIdentity(claims, AuthenticationType);
        var claimsPrincial = new ClaimsPrincipal(identity);
        var authState = new AuthenticationState(claimsPrincial);
        return authState;
    }
}
