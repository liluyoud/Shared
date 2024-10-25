using Dclt.Directus.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dclt.Directus.Entities;

public class EntitySecureWithArchive<T> : EntitySecure<T>, IEntityStatus
{
    [Column("status")]
    public string? Status { get; set; }
}
