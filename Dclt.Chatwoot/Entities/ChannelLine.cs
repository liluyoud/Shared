using System;
using System.Collections.Generic;

namespace Dclt.Chatwoot.Entities;

public partial class ChannelLine
{
    public long Id { get; set; }

    public int AccountId { get; set; }

    public string LineChannelId { get; set; } = null!;

    public string LineChannelSecret { get; set; } = null!;

    public string LineChannelToken { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
