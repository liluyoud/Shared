using System;
using System.Collections.Generic;

namespace Dclt.Chatwoot.Entities;

public partial class RelatedCategory
{
    public long Id { get; set; }

    public long? CategoryId { get; set; }

    public long? RelatedCategoryId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
