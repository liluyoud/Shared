using System;
using System.Collections.Generic;

namespace Dclt.Chatwoot.Entities;

public partial class Message
{
    public int Id { get; set; }

    public string? Content { get; set; }

    public int AccountId { get; set; }

    public int InboxId { get; set; }

    public int ConversationId { get; set; }

    public int MessageType { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public bool Private { get; set; }

    public int? Status { get; set; }

    public string? SourceId { get; set; }

    public int ContentType { get; set; }

    public string? ContentAttributes { get; set; }

    public string? SenderType { get; set; }

    public long? SenderId { get; set; }

    public string? ExternalSourceIds { get; set; }

    public string? AdditionalAttributes { get; set; }

    public string? ProcessedMessageContent { get; set; }

    public string? Sentiment { get; set; }
}
