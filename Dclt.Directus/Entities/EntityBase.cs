using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Dclt.Directus.Entities;

public class EntityBase<T>
{
    [Key]
    [Column("id")]
    public required T Id { get; set; }
}
