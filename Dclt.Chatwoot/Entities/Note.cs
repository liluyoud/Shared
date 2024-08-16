using System;
using System.Collections.Generic;

namespace Dclt.Chatwoot.Entities;

public partial class Note
{
    public long Id { get; set; }

    public string Content { get; set; } = null!;

    public long AccountId { get; set; }

    public long ContactId { get; set; }

    public long? UserId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
