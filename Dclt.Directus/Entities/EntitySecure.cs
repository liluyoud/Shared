using Dclt.Directus.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dclt.Directus.Entities;

public class EntitySecure<T> : EntityBase<T>, IEntitySecure
{
    [Column("user_created")]
    public Guid? UserCreated { get; set; }

    [Column("date_created")]
    public DateTime? DateCreated { get; set; }

    [Column("user_updated")]
    public Guid? UserUpdated { get; set; }

    [Column("date_updated")]
    public DateTime? DateUpdated { get; set; }
}
