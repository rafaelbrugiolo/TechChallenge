namespace TechChallenge.Domain.Entities;

public class Person : BaseEntity
{
    public string Name { get; set; }
    public DateTime Birthdate { get; set; }
    public string? AvatarFileName { get; set; }
}
