using System;
using System.Collections.Generic;

namespace Dclt.Chatwoot.Entities;

public partial class Tag
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? TaggingsCount { get; set; }
}
