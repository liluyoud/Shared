using System;
using System.Collections.Generic;

namespace Dclt.Chatwoot.Entities;

public partial class Conversation
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int InboxId { get; set; }

    public int Status { get; set; }

    public int? AssigneeId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public long? ContactId { get; set; }

    public int DisplayId { get; set; }

    public DateTime? ContactLastSeenAt { get; set; }

    public DateTime? AgentLastSeenAt { get; set; }

    public string? AdditionalAttributes { get; set; }

    public long? ContactInboxId { get; set; }

    public Guid Uuid { get; set; }

    public string? Identifier { get; set; }

    public DateTime LastActivityAt { get; set; }

    public long? TeamId { get; set; }

    public long? CampaignId { get; set; }

    public DateTime? SnoozedUntil { get; set; }

    public string? CustomAttributes { get; set; }

    public DateTime? AssigneeLastSeenAt { get; set; }

    public DateTime? FirstReplyCreatedAt { get; set; }

    public int? Priority { get; set; }

    public long? SlaPolicyId { get; set; }

    public DateTime? WaitingSince { get; set; }

    public string? CachedLabelList { get; set; }
}
