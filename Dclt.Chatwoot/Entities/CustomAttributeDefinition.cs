using System;
using System.Collections.Generic;

namespace Dclt.Chatwoot.Entities;

public partial class CustomAttributeDefinition
{
    public long Id { get; set; }

    public string? AttributeDisplayName { get; set; }

    public string? AttributeKey { get; set; }

    public int? AttributeDisplayType { get; set; }

    public int? DefaultValue { get; set; }

    public int? AttributeModel { get; set; }

    public long? AccountId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? AttributeDescription { get; set; }

    public string? AttributeValues { get; set; }

    public string? RegexPattern { get; set; }

    public string? RegexCue { get; set; }
}
