using System;
using System.Collections.Generic;

namespace Dclt.Chatwoot.Entities;

public partial class Contact
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public int AccountId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? AdditionalAttributes { get; set; }

    public string? Identifier { get; set; }

    public string? CustomAttributes { get; set; }

    public DateTime? LastActivityAt { get; set; }

    public int? ContactType { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public string? Location { get; set; }

    public string? CountryCode { get; set; }

    public bool Blocked { get; set; }
}
