using System.ComponentModel;

namespace Dclt.Chatwoot.Enums;

public enum AssigneeType
{
    [Description("all")]
    All,
    [Description("me")]
    Me,
    [Description("unassigned")]
    Unassigned,
    [Description("assigned")]
    Assigned
}
