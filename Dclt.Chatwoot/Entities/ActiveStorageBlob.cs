using System;
using System.Collections.Generic;

namespace Dclt.Chatwoot.Entities;

public partial class ActiveStorageBlob
{
    public long Id { get; set; }

    public string Key { get; set; } = null!;

    public string Filename { get; set; } = null!;

    public string? ContentType { get; set; }

    public string? Metadata { get; set; }

    public long ByteSize { get; set; }

    public string? Checksum { get; set; }

    public DateTime CreatedAt { get; set; }

    public string ServiceName { get; set; } = null!;

    public virtual ICollection<ActiveStorageAttachment> ActiveStorageAttachments { get; set; } = new List<ActiveStorageAttachment>();

    public virtual ICollection<ActiveStorageVariantRecord> ActiveStorageVariantRecords { get; set; } = new List<ActiveStorageVariantRecord>();
}
