namespace FidelityCard.Application.Dtos.Response;
public class CustomerResponseDto
{
    public Guid Id { get; set; }
    public Guid CompanyId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Birthdate { get; set; }
    public string ContactPhone { get; set; }

	public CompanyResponseDto Company { get; set; }
}
