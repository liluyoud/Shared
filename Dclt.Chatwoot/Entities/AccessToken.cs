using System;
using System.Collections.Generic;

namespace Dclt.Chatwoot.Entities;

public partial class AccessToken
{
    public long Id { get; set; }

    public string? OwnerType { get; set; }

    public long? OwnerId { get; set; }

    public string? Token { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
