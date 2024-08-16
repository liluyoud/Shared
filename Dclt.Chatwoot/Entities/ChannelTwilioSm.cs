using System;
using System.Collections.Generic;

namespace Dclt.Chatwoot.Entities;

public partial class ChannelTwilioSm
{
    public long Id { get; set; }

    public string? PhoneNumber { get; set; }

    public string AuthToken { get; set; } = null!;

    public string AccountSid { get; set; } = null!;

    public int AccountId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int? Medium { get; set; }

    public string? MessagingServiceSid { get; set; }

    public string? ApiKeySid { get; set; }
}
