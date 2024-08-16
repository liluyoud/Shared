using System;
using System.Collections.Generic;

namespace Dclt.Chatwoot.Entities;

public partial class Webhook
{
    public long Id { get; set; }

    public int? AccountId { get; set; }

    public int? InboxId { get; set; }

    public string? Url { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int? WebhookType { get; set; }

    public string? Subscriptions { get; set; }
}
