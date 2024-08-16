using System;
using System.Collections.Generic;

namespace Dclt.Chatwoot.Entities;

public partial class IntegrationsHook
{
    public long Id { get; set; }

    public int? Status { get; set; }

    public int? InboxId { get; set; }

    public int? AccountId { get; set; }

    public string? AppId { get; set; }

    public int? HookType { get; set; }

    public string? ReferenceId { get; set; }

    public string? AccessToken { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? Settings { get; set; }
}
