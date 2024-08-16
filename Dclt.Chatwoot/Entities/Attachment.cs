using System;
using System.Collections.Generic;

namespace Dclt.Chatwoot.Entities;

public partial class Attachment
{
    public int Id { get; set; }

    public int? FileType { get; set; }

    public string? ExternalUrl { get; set; }

    public double? CoordinatesLat { get; set; }

    public double? CoordinatesLong { get; set; }

    public int MessageId { get; set; }

    public int AccountId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? FallbackTitle { get; set; }

    public string? Extension { get; set; }
}
