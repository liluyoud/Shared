namespace Dclt.Directus.Interfaces;

public interface IEntitySecure
{
    public Guid? UserCreated { get; set; }
    public DateTime? DateCreated { get; set; }
    public Guid? UserUpdated { get; set; }
    public DateTime? DateUpdated { get; set; }
}
