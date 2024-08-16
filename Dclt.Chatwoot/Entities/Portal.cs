using System;
using System.Collections.Generic;

namespace Dclt.Chatwoot.Entities;

public partial class Portal
{
    public long Id { get; set; }

    public int AccountId { get; set; }

    public string Name { get; set; } = null!;

    public string Slug { get; set; } = null!;

    public string? CustomDomain { get; set; }

    public string? Color { get; set; }

    public string? HomepageLink { get; set; }

    public string? PageTitle { get; set; }

    public string? HeaderText { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? Config { get; set; }

    public bool? Archived { get; set; }

    public long? ChannelWebWidgetId { get; set; }

    public virtual ICollection<Inbox> Inboxes { get; set; } = new List<Inbox>();
}
