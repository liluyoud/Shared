using System;
using System.Collections.Generic;

namespace Dclt.Chatwoot.Entities;

public partial class ContactInbox
{
    public long Id { get; set; }

    public long? ContactId { get; set; }

    public long? InboxId { get; set; }

    public string SourceId { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public bool? HmacVerified { get; set; }

    public string? PubsubToken { get; set; }
}
