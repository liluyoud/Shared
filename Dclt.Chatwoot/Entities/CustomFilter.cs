using System;
using System.Collections.Generic;

namespace Dclt.Chatwoot.Entities;

public partial class CustomFilter
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public int FilterType { get; set; }

    public string Query { get; set; } = null!;

    public long AccountId { get; set; }

    public long UserId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
