using System;
using System.Collections.Generic;

namespace Dclt.Chatwoot.Entities;

public partial class DashboardApp
{
    public long Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Content { get; set; }

    public long AccountId { get; set; }

    public long? UserId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
