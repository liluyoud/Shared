using System;
using System.Collections.Generic;

namespace Dclt.Chatwoot.Entities;

public partial class Folder
{
    public long Id { get; set; }

    public int AccountId { get; set; }

    public int CategoryId { get; set; }

    public string? Name { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
