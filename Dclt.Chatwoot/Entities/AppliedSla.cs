using System;
using System.Collections.Generic;

namespace Dclt.Chatwoot.Entities;

public partial class AppliedSla
{
    public long Id { get; set; }

    public long AccountId { get; set; }

    public long SlaPolicyId { get; set; }

    public long ConversationId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int? SlaStatus { get; set; }
}
