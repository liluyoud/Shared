using System;
using System.Collections.Generic;

namespace Dclt.Chatwoot.Entities;

public partial class Team
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public bool? AllowAutoAssign { get; set; }

    public long AccountId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
