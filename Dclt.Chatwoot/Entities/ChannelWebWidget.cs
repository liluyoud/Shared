using System;
using System.Collections.Generic;

namespace Dclt.Chatwoot.Entities;

public partial class ChannelWebWidget
{
    public int Id { get; set; }

    public string? WebsiteUrl { get; set; }

    public int? AccountId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? WebsiteToken { get; set; }

    public string? WidgetColor { get; set; }

    public string? WelcomeTitle { get; set; }

    public string? WelcomeTagline { get; set; }

    public int FeatureFlags { get; set; }

    public int? ReplyTime { get; set; }

    public string? HmacToken { get; set; }

    public bool? PreChatFormEnabled { get; set; }

    public string? PreChatFormOptions { get; set; }

    public bool? HmacMandatory { get; set; }

    public bool ContinuityViaEmail { get; set; }
}
