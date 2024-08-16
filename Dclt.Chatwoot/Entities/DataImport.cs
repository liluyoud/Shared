using System;
using System.Collections.Generic;

namespace Dclt.Chatwoot.Entities;

public partial class DataImport
{
    public long Id { get; set; }

    public long AccountId { get; set; }

    public string DataType { get; set; } = null!;

    public int Status { get; set; }

    public string? ProcessingErrors { get; set; }

    public int? TotalRecords { get; set; }

    public int? ProcessedRecords { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
