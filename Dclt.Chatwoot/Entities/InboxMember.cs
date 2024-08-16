using System;
using System.Collections.Generic;

namespace Dclt.Chatwoot.Entities;

public partial class InboxMember
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int InboxId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
