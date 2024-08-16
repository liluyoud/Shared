using System;
using System.Collections.Generic;

namespace Dclt.Chatwoot.Entities;

public partial class User
{
    public int Id { get; set; }

    public string Provider { get; set; } = null!;

    public string Uid { get; set; } = null!;

    public string EncryptedPassword { get; set; } = null!;

    public string? ResetPasswordToken { get; set; }

    public DateTime? ResetPasswordSentAt { get; set; }

    public DateTime? RememberCreatedAt { get; set; }

    public int SignInCount { get; set; }

    public DateTime? CurrentSignInAt { get; set; }

    public DateTime? LastSignInAt { get; set; }

    public string? CurrentSignInIp { get; set; }

    public string? LastSignInIp { get; set; }

    public string? ConfirmationToken { get; set; }

    public DateTime? ConfirmedAt { get; set; }

    public DateTime? ConfirmationSentAt { get; set; }

    public string? UnconfirmedEmail { get; set; }

    public string Name { get; set; } = null!;

    public string? DisplayName { get; set; }

    public string? Email { get; set; }

    public string? Tokens { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? PubsubToken { get; set; }

    public int? Availability { get; set; }

    public string? UiSettings { get; set; }

    public string? CustomAttributes { get; set; }

    public string? Type { get; set; }

    public string? MessageSignature { get; set; }
}
