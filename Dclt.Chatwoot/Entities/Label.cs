using System;
using System.Collections.Generic;

namespace Dclt.Chatwoot.Entities;

public partial class Label
{
    public long Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string Color { get; set; } = null!;

    public bool? ShowOnSidebar { get; set; }

    public long? AccountId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
