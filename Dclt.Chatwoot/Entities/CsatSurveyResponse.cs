using System;
using System.Collections.Generic;

namespace Dclt.Chatwoot.Entities;

public partial class CsatSurveyResponse
{
    public long Id { get; set; }

    public long AccountId { get; set; }

    public long ConversationId { get; set; }

    public long MessageId { get; set; }

    public int Rating { get; set; }

    public string? FeedbackMessage { get; set; }

    public long ContactId { get; set; }

    public long? AssignedAgentId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
