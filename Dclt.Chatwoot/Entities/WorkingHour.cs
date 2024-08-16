using System;
using System.Collections.Generic;

namespace Dclt.Chatwoot.Entities;

public partial class WorkingHour
{
    public long Id { get; set; }

    public long? InboxId { get; set; }

    public long? AccountId { get; set; }

    public int DayOfWeek { get; set; }

    public bool? ClosedAllDay { get; set; }

    public int? OpenHour { get; set; }

    public int? OpenMinutes { get; set; }

    public int? CloseHour { get; set; }

    public int? CloseMinutes { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public bool? OpenAllDay { get; set; }
}
