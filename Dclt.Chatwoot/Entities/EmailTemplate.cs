using System;
using System.Collections.Generic;

namespace Dclt.Chatwoot.Entities;

public partial class EmailTemplate
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Body { get; set; } = null!;

    public int? AccountId { get; set; }

    public int? TemplateType { get; set; }

    public int Locale { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
