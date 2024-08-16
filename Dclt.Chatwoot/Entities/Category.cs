using System;
using System.Collections.Generic;

namespace Dclt.Chatwoot.Entities;

public partial class Category
{
    public long Id { get; set; }

    public int AccountId { get; set; }

    public int PortalId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? Position { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? Locale { get; set; }

    public string Slug { get; set; } = null!;

    public long? ParentCategoryId { get; set; }

    public long? AssociatedCategoryId { get; set; }

    public string? Icon { get; set; }
}
