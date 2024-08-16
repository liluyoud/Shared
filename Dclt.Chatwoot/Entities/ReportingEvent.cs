using System;
using System.Collections.Generic;

namespace Dclt.Chatwoot.Entities;

public partial class ReportingEvent
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public double? Value { get; set; }

    public int? AccountId { get; set; }

    public int? InboxId { get; set; }

    public int? UserId { get; set; }

    public int? ConversationId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public double? ValueInBusinessHours { get; set; }

    public DateTime? EventStartTime { get; set; }

    public DateTime? EventEndTime { get; set; }
}
