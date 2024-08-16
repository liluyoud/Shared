using System;
using System.Collections.Generic;

namespace Dclt.Chatwoot.Entities;

public partial class AccountUser
{
    public long Id { get; set; }

    public long? AccountId { get; set; }

    public long? UserId { get; set; }

    public int? Role { get; set; }

    public long? InviterId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public DateTime? ActiveAt { get; set; }

    public int Availability { get; set; }

    public bool AutoOffline { get; set; }
}
