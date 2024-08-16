using System;
using System.Collections.Generic;

namespace Dclt.Chatwoot.Entities;

public partial class ConversationParticipant
{
    public long Id { get; set; }

    public long AccountId { get; set; }

    public long UserId { get; set; }

    public long ConversationId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
