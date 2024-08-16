using System;
using System.Collections.Generic;

namespace Dclt.Chatwoot.Entities;

public partial class Account
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int? Locale { get; set; }

    public string? Domain { get; set; }

    public string? SupportEmail { get; set; }

    public long FeatureFlags { get; set; }

    public int? AutoResolveDuration { get; set; }

    public string? Limits { get; set; }

    public string? CustomAttributes { get; set; }

    public int? Status { get; set; }
}
