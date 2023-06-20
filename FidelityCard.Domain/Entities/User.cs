namespace FidelityCard.Domain.Entities;

public class User : BaseEntity
{
    public Guid CompanyId { get; set; }
    public string Name { get; set; }
    public string? Email { get; set; }
    public string? AvatarFileName { get; set; }

	public virtual Company Company { get; set; }
}
