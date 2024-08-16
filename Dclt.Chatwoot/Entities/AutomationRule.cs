using System;
using System.Collections.Generic;

namespace Dclt.Chatwoot.Entities;

public partial class AutomationRule
{
    public long Id { get; set; }

    public long AccountId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string EventName { get; set; } = null!;

    public string Conditions { get; set; } = null!;

    public string Actions { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public bool Active { get; set; }
}
