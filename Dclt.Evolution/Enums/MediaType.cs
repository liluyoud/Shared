using System.ComponentModel;

namespace Dclt.Evolution.Enums;

public enum MediaType
{
    [Description("image")]
    Image,
    [Description("video")]
    Video,
    [Description("audio")]
    Audio,
    [Description("document")]
    Document
}
