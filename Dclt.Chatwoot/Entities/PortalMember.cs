using System;
using System.Collections.Generic;

namespace Dclt.Chatwoot.Entities;

public partial class PortalMember
{
    public long Id { get; set; }

    public long? PortalId { get; set; }

    public long? UserId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
