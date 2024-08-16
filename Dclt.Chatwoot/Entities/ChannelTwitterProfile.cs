using System;
using System.Collections.Generic;

namespace Dclt.Chatwoot.Entities;

public partial class ChannelTwitterProfile
{
    public long Id { get; set; }

    public string ProfileId { get; set; } = null!;

    public string TwitterAccessToken { get; set; } = null!;

    public string TwitterAccessTokenSecret { get; set; } = null!;

    public int AccountId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public bool? TweetsEnabled { get; set; }
}
