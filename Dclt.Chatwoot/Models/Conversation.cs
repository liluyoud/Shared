using Dclt.Chatwoot.Models.Api;
using System.Text.Json.Serialization;

namespace Dclt.Chatwoot.Models;

public class Conversation
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public int InboxId { get; set; }
    public Guid? Uuid { get; set; }
    public Attendee? Agent { get; set; }
    public DateTime AgentLastSeenAt { get; set; }
    public Attendee? Contact { get; set; }
    public DateTime ContactLastSeenAt { get; set; }
    public string[]? Labels { get; set; }
    public bool Muted { get; set; }
    public string? Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime Timestamp { get; set; }
    public DateTime FirstReplyCreatedAt { get; set; }
    public DateTime LastActivityAt { get; set; }
    public DateTime? SnoozedUntil { get; set; }
    public DateTime WaitingSince { get; set; }
    public int UnreadCount { get; set; }
}
