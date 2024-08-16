using System;
using System.Collections.Generic;

namespace Dclt.Chatwoot.Entities;

public partial class InstallationConfig
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string SerializedValue { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public bool Locked { get; set; }
}
