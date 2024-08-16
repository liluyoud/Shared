using System;
using System.Collections.Generic;

namespace Dclt.Chatwoot.Entities;

public partial class CannedResponse
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public string? ShortCode { get; set; }

    public string? Content { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
