using System;
using System.Collections.Generic;

namespace Dclt.Chatwoot.Entities;

public partial class AgentBot
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? OutgoingUrl { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public long? AccountId { get; set; }

    public int? BotType { get; set; }

    public string? BotConfig { get; set; }
}
