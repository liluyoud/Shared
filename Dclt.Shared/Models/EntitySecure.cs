using System.ComponentModel.DataAnnotations;

namespace Dclt.Shared.Models;

public abstract class EntitySecure<T>: EntityBase<T> where T : struct
{
    [StringLength(14)]
    public string? CreatedBy { get; set; }

    [StringLength(14)]
    public string? ModifiedBy { get; set; }

    [StringLength(14)]
    public string? DeletedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public int? Version { get; set; }

}
