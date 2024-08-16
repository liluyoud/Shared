using System;
using System.Collections.Generic;

namespace Dclt.Chatwoot.Entities;

public partial class Campaign
{
    public long Id { get; set; }

    public int DisplayId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string Message { get; set; } = null!;

    public int? SenderId { get; set; }

    public bool? Enabled { get; set; }

    public long AccountId { get; set; }

    public long InboxId { get; set; }

    public string? TriggerRules { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int CampaignType { get; set; }

    public int CampaignStatus { get; set; }

    public string? Audience { get; set; }

    public DateTime? ScheduledAt { get; set; }

    public bool? TriggerOnlyDuringBusinessHours { get; set; }
}
