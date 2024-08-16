using System;
using System.Collections.Generic;

namespace Dclt.Chatwoot.Entities;

public partial class Article
{
    public long Id { get; set; }

    public int AccountId { get; set; }

    public int PortalId { get; set; }

    public int? CategoryId { get; set; }

    public int? FolderId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Content { get; set; }

    public int? Status { get; set; }

    public int? Views { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public long? AuthorId { get; set; }

    public long? AssociatedArticleId { get; set; }

    public string? Meta { get; set; }

    public string Slug { get; set; } = null!;

    public int? Position { get; set; }
}
