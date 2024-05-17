using System.ComponentModel.DataAnnotations;

namespace Dclt.Shared.Models;

public abstract class EntityBase<T> where T : struct
{
    [Key]
    public T Id { get; set; }
}
