using System;
using System.Collections.Generic;

namespace Dclt.Chatwoot.Entities;

public partial class Inbox
{
    public int Id { get; set; }

    public int ChannelId { get; set; }

    public int AccountId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? ChannelType { get; set; }

    public bool? EnableAutoAssignment { get; set; }

    public bool? GreetingEnabled { get; set; }

    public string? GreetingMessage { get; set; }

    public string? EmailAddress { get; set; }

    public bool? WorkingHoursEnabled { get; set; }

    public string? OutOfOfficeMessage { get; set; }

    public string? Timezone { get; set; }

    public bool? EnableEmailCollect { get; set; }

    public bool? CsatSurveyEnabled { get; set; }

    public bool? AllowMessagesAfterResolved { get; set; }

    public string? AutoAssignmentConfig { get; set; }

    public bool LockToSingleConversation { get; set; }

    public long? PortalId { get; set; }

    public int SenderNameType { get; set; }

    public string? BusinessName { get; set; }

    public virtual Portal? Portal { get; set; }
}
