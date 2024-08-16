using System;
using System.Collections.Generic;

namespace Dclt.Chatwoot.Entities;

public partial class PlatformApp
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
