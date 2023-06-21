namespace FidelityCard.Application.Dtos.Request;
public class CustomerRequestDto
{
    public Guid CompanyId { get; set; }
    public string Name { get; set; }
    public string? Email { get; set; }
    public string? Birthdate { get; set; }
    public string? ContactPhone { get; set; }
}
