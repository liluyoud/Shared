namespace Dclt.Shared.Models.Authentication;

public class AuthenticationModel
{
    public string? TokenType { get; set; }
    public string? AccessToken { get; set; }
    public string? RefreshToken { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }

}
