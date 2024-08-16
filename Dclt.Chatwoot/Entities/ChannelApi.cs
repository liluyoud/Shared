using System;
using System.Collections.Generic;

namespace Dclt.Chatwoot.Entities;

public partial class ChannelApi
{
    public long Id { get; set; }

    public int AccountId { get; set; }

    public string? WebhookUrl { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? Identifier { get; set; }

    public string? HmacToken { get; set; }

    public bool? HmacMandatory { get; set; }

    public string? AdditionalAttributes { get; set; }
}
