using System;
using System.Collections.Generic;

namespace Dclt.Chatwoot.Entities;

public partial class NotificationSubscription
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public int SubscriptionType { get; set; }

    public string SubscriptionAttributes { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? Identifier { get; set; }
}
