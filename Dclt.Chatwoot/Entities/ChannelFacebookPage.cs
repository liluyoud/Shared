using System;
using System.Collections.Generic;

namespace Dclt.Chatwoot.Entities;

public partial class ChannelFacebookPage
{
    public int Id { get; set; }

    public string PageId { get; set; } = null!;

    public string UserAccessToken { get; set; } = null!;

    public string PageAccessToken { get; set; } = null!;

    public int AccountId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? InstagramId { get; set; }
}
