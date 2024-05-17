using System.ComponentModel.DataAnnotations;

namespace Dclt.Shared.Models.Authentication;

public record LoginModel()
{
    [Required] 
    public string? Username { get; set; }

    [DataType(DataType.Password), Required]
    public string? Password { get; set; }
}
