using System;
using System.Collections.Generic;

namespace Dclt.Chatwoot.Entities;

public partial class ChannelEmail
{
    public long Id { get; set; }

    public int AccountId { get; set; }

    public string Email { get; set; } = null!;

    public string ForwardToEmail { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public bool? ImapEnabled { get; set; }

    public string? ImapAddress { get; set; }

    public int? ImapPort { get; set; }

    public string? ImapLogin { get; set; }

    public string? ImapPassword { get; set; }

    public bool? ImapEnableSsl { get; set; }

    public bool? SmtpEnabled { get; set; }

    public string? SmtpAddress { get; set; }

    public int? SmtpPort { get; set; }

    public string? SmtpLogin { get; set; }

    public string? SmtpPassword { get; set; }

    public string? SmtpDomain { get; set; }

    public bool? SmtpEnableStarttlsAuto { get; set; }

    public string? SmtpAuthentication { get; set; }

    public string? SmtpOpensslVerifyMode { get; set; }

    public bool? SmtpEnableSslTls { get; set; }

    public string? ProviderConfig { get; set; }

    public string? Provider { get; set; }
}
