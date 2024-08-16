using System;
using System.Collections.Generic;

namespace Dclt.Chatwoot.Entities;

public partial class Notification
{
    public long Id { get; set; }

    public long AccountId { get; set; }

    public long UserId { get; set; }

    public int NotificationType { get; set; }

    public string PrimaryActorType { get; set; } = null!;

    public long PrimaryActorId { get; set; }

    public string? SecondaryActorType { get; set; }

    public long? SecondaryActorId { get; set; }

    public DateTime? ReadAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public DateTime? SnoozedUntil { get; set; }

    public DateTime? LastActivityAt { get; set; }

    public string? Meta { get; set; }
}
