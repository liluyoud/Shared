using System;
using System.Collections.Generic;

namespace Dclt.Chatwoot.Entities;

public partial class Audit
{
    public long Id { get; set; }

    public long? AuditableId { get; set; }

    public string? AuditableType { get; set; }

    public long? AssociatedId { get; set; }

    public string? AssociatedType { get; set; }

    public long? UserId { get; set; }

    public string? UserType { get; set; }

    public string? Username { get; set; }

    public string? Action { get; set; }

    public string? AuditedChanges { get; set; }

    public int? Version { get; set; }

    public string? Comment { get; set; }

    public string? RemoteAddress { get; set; }

    public string? RequestUuid { get; set; }

    public DateTime? CreatedAt { get; set; }
}
