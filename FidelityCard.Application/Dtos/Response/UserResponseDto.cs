namespace FidelityCard.Application.Dtos.Response;

public class UserResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
	public string? AvatarFileName { get; set; }
	public string? AvatarContent { get; set; }
}