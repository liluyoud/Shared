using System;
using System.Collections.Generic;

namespace Dclt.Chatwoot.Entities;

public partial class SlaEvent
{
    public long Id { get; set; }

    public long AppliedSlaId { get; set; }

    public long ConversationId { get; set; }

    public long AccountId { get; set; }

    public long SlaPolicyId { get; set; }

    public long InboxId { get; set; }

    public int? EventType { get; set; }

    public string? Meta { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
