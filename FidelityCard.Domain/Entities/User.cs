namespace FidelityCard.Domain.Entities;

public class User : BaseEntity
{
    public string Name { get; set; }
    public DateTime Birthdate { get; set; }
    public string? AvatarFileName { get; set; }
}
