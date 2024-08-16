using System;
using System.Collections.Generic;

namespace Dclt.Chatwoot.Entities;

public partial class Macro
{
    public long Id { get; set; }

    public long AccountId { get; set; }

    public string Name { get; set; } = null!;

    public int? Visibility { get; set; }

    public long? CreatedById { get; set; }

    public long? UpdatedById { get; set; }

    public string Actions { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
