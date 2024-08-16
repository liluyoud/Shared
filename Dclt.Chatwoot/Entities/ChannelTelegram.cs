using System;
using System.Collections.Generic;

namespace Dclt.Chatwoot.Entities;

public partial class ChannelTelegram
{
    public long Id { get; set; }

    public string? BotName { get; set; }

    public int AccountId { get; set; }

    public string BotToken { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
