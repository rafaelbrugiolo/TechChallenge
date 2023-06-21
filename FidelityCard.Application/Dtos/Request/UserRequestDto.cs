namespace FidelityCard.Application.Dtos.Request;

public class UserRequestDto
{
    public Guid CompanyId { get; set; }
    public string Name { get; set; }
	public string Email { get; set; }
}