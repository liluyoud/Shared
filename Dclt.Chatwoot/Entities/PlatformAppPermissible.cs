using System;
using System.Collections.Generic;

namespace Dclt.Chatwoot.Entities;

public partial class PlatformAppPermissible
{
    public long Id { get; set; }

    public long PlatformAppId { get; set; }

    public string PermissibleType { get; set; } = null!;

    public long PermissibleId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
