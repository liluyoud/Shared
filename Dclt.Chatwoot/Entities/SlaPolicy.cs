using System;
using System.Collections.Generic;

namespace Dclt.Chatwoot.Entities;

public partial class SlaPolicy
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public double? FirstResponseTimeThreshold { get; set; }

    public double? NextResponseTimeThreshold { get; set; }

    public bool? OnlyDuringBusinessHours { get; set; }

    public long AccountId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? Description { get; set; }

    public double? ResolutionTimeThreshold { get; set; }
}
