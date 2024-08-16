using System;
using System.Collections.Generic;

namespace Dclt.Chatwoot.Entities;

public partial class ChannelSm
{
    public long Id { get; set; }

    public int AccountId { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string? Provider { get; set; }

    public string? ProviderConfig { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
