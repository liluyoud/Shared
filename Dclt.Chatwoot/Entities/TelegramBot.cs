using System;
using System.Collections.Generic;

namespace Dclt.Chatwoot.Entities;

public partial class TelegramBot
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? AuthKey { get; set; }

    public int? AccountId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
