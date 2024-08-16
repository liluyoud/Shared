using System;
using System.Collections.Generic;

namespace Dclt.Chatwoot.Entities;

public partial class ActionMailboxInboundEmail
{
    public long Id { get; set; }

    public int Status { get; set; }

    public string MessageId { get; set; } = null!;

    public string MessageChecksum { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
