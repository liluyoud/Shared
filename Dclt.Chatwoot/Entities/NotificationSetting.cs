using System;
using System.Collections.Generic;

namespace Dclt.Chatwoot.Entities;

public partial class NotificationSetting
{
    public long Id { get; set; }

    public int? AccountId { get; set; }

    public int? UserId { get; set; }

    public int EmailFlags { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int PushFlags { get; set; }
}
