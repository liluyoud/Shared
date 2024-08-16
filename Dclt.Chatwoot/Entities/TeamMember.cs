using System;
using System.Collections.Generic;

namespace Dclt.Chatwoot.Entities;

public partial class TeamMember
{
    public long Id { get; set; }

    public long TeamId { get; set; }

    public long UserId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
