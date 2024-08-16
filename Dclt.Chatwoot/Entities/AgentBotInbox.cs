using System;
using System.Collections.Generic;

namespace Dclt.Chatwoot.Entities;

public partial class AgentBotInbox
{
    public long Id { get; set; }

    public int? InboxId { get; set; }

    public int? AgentBotId { get; set; }

    public int? Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int? AccountId { get; set; }
}
