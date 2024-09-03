using System.ComponentModel;

namespace Dclt.Chatwoot.Enums;

public enum AttendeeType
{
    [Description("all")]
    User,
    [Description("me")]
    Contact,
    [Description("unassigned")]
    Unassigned,
    [Description("assigned")]
    Assigned
}
