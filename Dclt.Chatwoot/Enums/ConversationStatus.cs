using System.ComponentModel;

namespace Dclt.Chatwoot.Enums;

public enum ConversationStatus
{
    [Description("open")]
    Open,
    [Description("resolved")]
    Resolved,
    [Description("pending")]
    Pending,
    [Description("snoozed")]
    Snoozed
}
